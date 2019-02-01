using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using MyFoundation.Interfaces;
using Schema.NET;

namespace ContentComponents.Models
{
    public class YouTubeVideo : IMicrodata
    {
        [SitecoreField("YouTube Video Id")] public virtual string VideoId { get; set; }

        [SitecoreField("YouTube Video Autoplay")]
        public virtual Boolean Autoplay { get; set; }
        public Thing GetMicrodata(IAuthorResolver authorResolver)
        {
            return new VideoObject();
        }
    }
}