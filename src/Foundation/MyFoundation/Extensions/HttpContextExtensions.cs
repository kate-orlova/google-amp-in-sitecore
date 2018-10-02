using System.Collections;
using System.Web;

namespace MyFoundation.Extensions
{
    public static class HttpContextExtensions
    {
        public static void SetAmpRequestFlag(this HttpContextBase context)
        {
            context.Items["amp"] = true;
        }

        public static bool IsAmpRequest(this HttpContextBase context)
        {
            return IsAmpRequest(context?.Items);
        }

        public static bool IsAmpRequest(this HttpContext context)
        {
            return IsAmpRequest(context?.Items);
        }

        private static bool IsAmpRequest(IDictionary items)
        {
            var ampFlag = items?["amp"];

            return ampFlag != null && (bool) ampFlag;
        }
    }
}