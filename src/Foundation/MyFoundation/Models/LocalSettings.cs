using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Schema.NET;

namespace MyFoundation.Models
{
    public class LocalSettings
    {
        [SitecoreField("Organisation Name")]
        public virtual string OrganizationName { get; set; }

        [SitecoreField("Organisation URL")]
        public virtual string OrganizationURL { get; set; }

        public Organization GetOrganizationMicrodata()
        {
            return new Organization
            {
                Name = OrganizationName,
                Url = new Uri(OrganizationURL ?? String.Empty, UriKind.RelativeOrAbsolute),
            };
        }
    }
}