using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        const int ShortURLSuffixLength = 6;

        private readonly ITinyUrlRepository repository;

        public DefaultUrlShorteningService(
            ITinyUrlRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> CreateShortURL(
            string url, 
            CancellationToken cancellationToken = default)
        {

            // Validate URL schema.
            if (Helpers.URLHelpers.IsValidURL(url))
            {
                // Create URL hash.
                var urlUtfBytes = Encoding.UTF8.GetBytes(url);
                var urlHash = SHA1.Create().ComputeHash(urlUtfBytes);
                var urlBase64String = Convert.ToBase64String(urlHash);

                var shortUrl = await repository.GetByHashAsync(urlBase64String, cancellationToken);
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

                await repository.AddAsync(entity, cancellationToken);

                return await Task.FromResult(entity.ShortUrl);
            }

            return await Task.FromResult(default(string));
        }

    }
}
