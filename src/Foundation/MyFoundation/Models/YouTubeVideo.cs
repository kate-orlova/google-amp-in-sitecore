﻿using Glass.Mapper.Sc.Configuration.Attributes;
using MyFoundation.Interfaces;
using Schema.NET;
using System;

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

        public Thing GetMicrodata(IAuthorResolver authorResolver)
        {
            return new VideoObject();
        }
    }
}