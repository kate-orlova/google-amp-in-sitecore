using Glass.Mapper.Sc.Configuration.Attributes;

namespace ContentComponents.Models
{
    public class InlineImage
    {
        [SitecoreField("Image")]
        public virtual MyFoundation.Models.Image Image { get; set; }
    }
}