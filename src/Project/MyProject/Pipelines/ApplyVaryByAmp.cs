using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using MyFoundation.Extensions;

namespace MyProject.Pipelines
{
    public class ApplyVaryByAmp : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (args.Rendered
                || HttpContext.Current == null
                || !args.Cacheable
                || string.IsNullOrWhiteSpace(args.CacheKey)
                || args.Rendering.RenderingItem == null)
            {
                return;
            }

            var rendering = args.PageContext.Database.GetItem(args.Rendering.RenderingItem.ID);

            if (rendering == null || rendering["VaryByAmp"] != "1")
            {
                return;
            }

            args.CacheKey += $"_#amp:{HttpContext.Current.IsAmpRequest()}";
        }
    }
}