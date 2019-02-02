using Glass.Mapper.Sc.Configuration.Attributes;
using MyFoundation.Interfaces;
using Schema.NET;
using System;
using MyFoundation.Extensions;

namespace MyFoundation.Models
{
    public class YouTubeVideo : IMicrodata
    {
        [SitecoreField("YouTube Video Id")]
        public virtual string VideoId { get; set; }

        [SitecoreField("YouTube Video Autoplay")]
        public virtual Boolean Autoplay { get; set; }

        [SitecoreField("Splash Image Screen")]
        public virtual Image SplashImageScreen { get; set; }

        [SitecoreField("SEO Video Name")]
        public virtual string SeoVideoName { get; set; }

        [SitecoreField("SEO Video Description")]
        public virtual string SeoVideoDescription { get; set; }

        public Thing GetMicrodata(IAuthorResolver authorResolver)
        {
            var splashImageScreen = SplashImageScreen.GetMicrodata(authorResolver);
            return new VideoObject
            {
                Id = new Uri(@"https://www.youtube.com/watch?v=" + (VideoId ?? string.Empty), UriKind.RelativeOrAbsolute),
                Thumbnail = splashImageScreen,
                ThumbnailUrl = new Uri(SplashImageScreen?.Src ?? string.Empty, UriKind.RelativeOrAbsolute),
                Author = authorResolver?.GetAuthor() ?? new Organization(),
                UploadDate = splashImageScreen.UploadDate
            };
        }
    }
}