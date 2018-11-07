﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyFoundation.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static readonly List<int> DefaultSrcSetSizes = new List<int> {320, 360, 640, 720, 960, 1280, 1440};

        public static string GetResizedMediaUrl(this HtmlHelper helper, string url, int maxWidth,
            string additionalParameters, bool externalSource = false)
        {
            return null;
        }

        private static string GetResizedSrcSet(this HtmlHelper helper, string url, string additionalParameters,
            bool externalSource, params int[] sizes)
        {
            var srcSetFormat = "{0} {1}w";
            var sizesList = new List<int>();
            sizesList.AddRange(DefaultSrcSetSizes);
            if (sizes != null)
            {
                sizesList.AddRange(sizes);
            }

            sizesList = sizesList.OrderBy(x => x).ToList();

            var srcSetList = new List<string>();
            foreach (var size in sizesList)
            {
                var resizedUrl = GetResizedMediaUrl(helper, url, size, additionalParameters, externalSource);
                srcSetList.Add(string.Format(srcSetFormat, resizedUrl, size));
            }

            return string.Join(",", srcSetList);
        }
    }
}