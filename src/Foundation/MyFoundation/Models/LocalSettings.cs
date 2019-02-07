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

        [SitecoreField("Organisation Logo")]
        public virtual Image OrganizationLogo { get; set; }

        [SitecoreField("Organisation Phone")]
        public virtual string ContactPhone { get; set; }

        [SitecoreField("Organisation Social Network Links")]
        public virtual string OrganizationSocialNetworkLinks { get; set; }

        public Organization GetOrganizationMicrodata()
        {
            return new Organization
            {
                Name = OrganizationName,
                Url = new Uri(OrganizationURL ?? String.Empty, UriKind.RelativeOrAbsolute),
                Logo = new ImageObject
                {
                    ContentUrl = new Uri(OrganizationLogo?.Src ?? String.Empty, UriKind.RelativeOrAbsolute),
                    Url = new Uri(OrganizationLogo?.Src ?? String.Empty, UriKind.RelativeOrAbsolute)
                },
                ContactPoint = new ContactPoint
                {
                    Telephone = ContactPhone ?? String.Empty,
                    ContactType = "customer service"
                }
            };
        }
    }
}