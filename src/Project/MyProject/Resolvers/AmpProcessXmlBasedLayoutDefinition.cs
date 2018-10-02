using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MyFoundation.Extensions;
using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines.Response.BuildPageDefinition;
using Sitecore.Mvc.Presentation;

namespace MyProject.Resolvers
{
    public class
        AmpProcessXmlBasedLayoutDefinition : Sitecore.Mvc.Pipelines.Response.BuildPageDefinition.
            ProcessXmlBasedLayoutDefinition
    {
        protected override IEnumerable<Rendering> GetRenderings(XElement layoutDefinition, BuildPageDefinitionArgs args)
        {
            var parser = MvcSettings.GetRegisteredObject<XmlBasedRenderingParser>();
            foreach (var node in layoutDefinition.Elements((XName) "d"))
            {
                var deviceNode = node;

                var deviceId = deviceNode.GetAttributeValueOrEmpty("id").ToGuid();
                var layoutId = deviceNode.GetAttributeValueOrEmpty("l").ToGuid();

                if (args.PageContext.RequestContext.HttpContext.IsAmpRequest())
                {
                    layoutId = new Guid(Sitecore.Configuration.Settings.GetSetting("MyProject.AmpLayoutId"));
                }

                yield return this.GetRendering(deviceNode, deviceId, layoutId, "Layout", parser);

                foreach (var element2 in deviceNode.Elements((XName) "r"))
                {
                    yield return this.GetRendering(element2, deviceId, layoutId, element2.Name.LocalName, parser);
                }
            }
        }
    }
}