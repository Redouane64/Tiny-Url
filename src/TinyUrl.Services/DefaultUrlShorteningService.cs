using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Data.Models;
using TinyUrl.Data.Repositories;

namespace TinyUrl.Services
{
    public class DefaultUrlShorteningService : IUrlShorteningService
    {
        const string HttpSchema = "http";
        const string HttpsSchema = "https";
        const string FtpSchema = "ftp";

        const int ShortURLSuffixLength = 6;

        private readonly IUrlsRepository repository;

        public DefaultUrlShorteningService(
            IUrlsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> GetShortUrl(string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);

            // Validate URL schema.
            if (IsValidSchema(uri.Scheme))
            {
                // Create URL hash.
                var urlUtfBytes = Encoding.UTF8.GetBytes(url);
                var urlHash = SHA1.Create().ComputeHash(urlUtfBytes);
                var urlBase64String = Convert.ToBase64String(urlHash);

                // TODO: Check in database for same URL using computed hash and return it if available.

                // Build entity.
                var suffix = urlBase64String.Take(ShortURLSuffixLength).ToArray();

                var entity = new Url
                {
                    OriginalUrl = url,
                    UrlHash = urlBase64String,
                    ShortUrl = new String(suffix)
                };

                // TODO: Save to database.

                return await Task.FromResult(entity.ShortUrl);
            }

            return await Task.FromResult(default(string));
        }

        private bool IsValidSchema(string scheme)
        {
            if(scheme == null)
            {
                throw new ArgumentNullException(nameof(scheme));
            }

            return scheme.Equals(HttpSchema, StringComparison.OrdinalIgnoreCase) || scheme.Equals(HttpsSchema, StringComparison.OrdinalIgnoreCase) || scheme.Equals(FtpSchema, StringComparison.OrdinalIgnoreCase);
        }
    }
}
