using System;
using MyFoundation.Models;
using Schema.NET;

namespace MyFoundation.Extensions
{
    public static class ImageExtensions
    {
        public static bool HasExternalSource(this Image image)
        {
            if (image == null)
            {
                return false;
            }

            return image.Src.NotEmpty() && image.MediaId == Guid.Empty;
        }
        public static ImageObject GetMicrodata(this Image image)
        {
            return new ImageObject();
            
        }
    }
}