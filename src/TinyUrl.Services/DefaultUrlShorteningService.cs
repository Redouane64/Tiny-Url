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
    /// <summary>
    /// Default URLs shortening service implementation.
    /// </summary>
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

        public async Task<string> CreateShortURL(string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);

            // Validate URL schema.
            if (IsValidSchema(uri.Scheme))
            {
                // Create URL hash.
                var urlUtfBytes = Encoding.UTF8.GetBytes(url);
                var urlHash = SHA1.Create().ComputeHash(urlUtfBytes);
                var urlBase64String = Convert.ToBase64String(urlHash);

                var shortUrl = await FindShortUrl(urlBase64String);
                if (shortUrl != null)
                {
                    return await Task.FromResult(shortUrl);
                }

                // Build entity.
                var suffix = urlBase64String.Take(ShortURLSuffixLength).ToArray();

                var entity = new Url
                {
                    OriginalUrl = url,
                    UrlHash = urlBase64String,
                    ShortUrl = new String(suffix)
                };

                await repository.AddAsync(entity);

                return await Task.FromResult(entity.ShortUrl);
            }

            return await Task.FromResult(default(string));
        }

        /// <summary>
        /// Find and retrieve an already shortened URL.
        /// </summary>
        /// <param name="urlHash">URL hash.</param>
        /// <returns>Shortened URL.</returns>
        private async ValueTask<string> FindShortUrl(string urlHash)
        {
            return await repository.GetByHashAsync(urlHash);
        }

        /// <summary>
        /// Validate URL schema.
        /// </summary>
        /// <param name="scheme">Schema from value.</param>
        /// <returns>True if schema is valid. False otherwise.</returns>
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
