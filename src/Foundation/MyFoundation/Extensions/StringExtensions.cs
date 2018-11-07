using System.Text.RegularExpressions;

namespace MyFoundation.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool NotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
        }
        public static string ToGeneralUrl(this string url)
        {
            if (url.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return Regex.Replace(url, "^http(s)?:", "");
        }
    }
}