using System;
using System.Collections.Generic;
using System.Text;

namespace TinyUrl.Data.Models
{
    /// <summary>
    /// Represents a URL entity.
    /// </summary>
    public class Url
    {
        public int Id { get; set; }

        /// <summary>
        /// Visits counter.
        /// </summary>
        public long VisitCount { get; set; }

        /// <summary>
        /// Original URL.
        /// </summary>
        public string OriginalUrl { get; set; }

        /// <summary>
        /// Base64 string for URL hash.
        /// </summary>
        public string UrlHash { get; set; }

        /// <summary>
        /// Short code for URL. (Without domain)
        /// </summary>
        public string ShortUrl { get; set; }
    }
}
