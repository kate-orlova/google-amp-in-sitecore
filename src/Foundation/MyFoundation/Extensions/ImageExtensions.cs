using System;
using MyFoundation.Interfaces;
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

        public static ImageObject GetMicrodata(this Image image, IAuthorResolver authorResolver)
        {
            return new ImageObject
            {
                Author = authorResolver?.GetAuthor() ?? new Organization(),
                Description = image?.Alt ?? String.Empty,
                ContentUrl = new Uri(image?.Src ?? String.Empty, UriKind.RelativeOrAbsolute),
                Url = new Uri(image?.Src ?? String.Empty, UriKind.RelativeOrAbsolute),
                ThumbnailUrl = new Uri(image?.Src ?? String.Empty, UriKind.RelativeOrAbsolute),
                UploadDate = (image?.DateUpdated ?? new DateTime()).ToDateTimeOffset()
            };
        }
    }
}