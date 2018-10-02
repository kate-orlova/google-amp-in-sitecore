using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MyFoundation.Extensions;
using MyFoundation.Constants;
using Sitecore.Abstractions;
using Sitecore.Configuration;
using Sitecore.Data.ItemResolvers;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.SecurityModel;

namespace MyProject.Resolvers
{
    public class AmpItemResolver : ItemResolver
    {
        public AmpItemResolver() : base(ServiceLocator.ServiceProvider.GetRequiredService<BaseItemManager>(),
            ServiceLocator.ServiceProvider.GetRequiredService<ItemPathResolver>())
        {
        }

        public AmpItemResolver(BaseItemManager itemManager, ItemPathResolver pathResolver)
            : base(itemManager, pathResolver, Settings.ItemResolving.FindBestMatch)
        {
        }

        protected AmpItemResolver(BaseItemManager itemManager, ItemPathResolver pathResolver,
            MixedItemNameResolvingMode itemNameResolvingMode)
            : base(itemManager, pathResolver, itemNameResolvingMode)
        {
        }

        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Item != null)
            {
                return;
            }

            if (IsAmpRequest(args))
            {
                base.Process(args);

                CheckResolvedItem(args);
            }
        }

        private void CheckResolvedItem(HttpRequestArgs args)
        {
            var item = Sitecore.Context.Item;

            if (item != null)
            {
                var field = (Sitecore.Data.Fields.CheckboxField) item.Fields[ItemFieldNames.HasAMPLayout];
                if (field?.Checked == true)
                {
                    args.HttpContext.SetAmpRequestFlag();
                }
                else
                {
                    Sitecore.Context.Item = null;
                }
            }
        }

        protected override Item ResolveByMixedDisplayName(HttpRequestArgs args, out bool accessDenied)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            accessDenied = false;

            Item item = null;

            using (new SecurityDisabler())
            {
                var site = Sitecore.Context.Site;
                if (site != null)
                {
                    item = this.ResolveEncodedMixedPath(args, site.RootPath,
                        args.LocalPath.Replace("/amp/", "").Replace("/amp", ""));
                }

                item = item
                       ?? this.ResolveEncodedMixedPath(StripAmp(args.Url.ItemPath), args)
                       ?? this.ResolveEncodedMixedPath(StripAmp(args.LocalPath), args);

                if (item == null)
                {
                    return null;
                }
            }

            accessDenied = !item.Access.CanRead();

            if (!accessDenied)
            {
                return item;
            }

            return null;
        }

        protected override IEnumerable<string> GetCandidatePaths(HttpRequestArgs args)
        {
            var paths = base.GetCandidatePaths(args).ToList();

            var ampLess = paths.Select(x => StripAmp(x));
            return ampLess;
        }

        protected virtual bool IsAmpRequest(HttpRequestArgs args)
        {
            return args.LocalPath.EndsWith("/amp") || args.LocalPath.EndsWith("/amp/");
        }

        protected string StripAmp(string url)
        {
            return url.Replace("/amp/", "").Replace("/amp", "");
        }
    }
}