using Glass.Mapper.Sc.Configuration.Attributes;

namespace ContentComponents.Models
{
    public class YouTubeVideo
    {
        [SitecoreField("YouTube Video Id")]
        public virtual string VideoId { get; set; }
    }
}