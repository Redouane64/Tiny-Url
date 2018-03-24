using System;
using System.Collections.Generic;
using System.Text;

namespace TinyUrl.Services.Helpers
{
    internal static class URLHelpers
    {
        /// <summary>
        /// Validate a URL and its schema.
        /// </summary>
        /// <param name="url">URL to validate.</param>
        /// <returns>True if URL is valid otherwise false.</returns>
        public static bool IsValidURL(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var result)
                && (result.Scheme == Uri.UriSchemeHttp
                || result.Scheme == Uri.UriSchemeHttps))
            {
                return true;
            }
            else
                return false;
        }

    }
}
