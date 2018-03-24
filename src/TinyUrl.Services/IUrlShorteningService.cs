using System.Threading;
using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Services
{
    public interface IUrlShorteningService
    {
        /// <summary>
        /// Create a short URL from a full URL.
        /// </summary>
        /// <param name="url">URL to shorten.</param>
        /// <returns>Short URL.</returns>
        Task<string> CreateShortURL(string url, CancellationToken cancellationToken = default);
    }
}
