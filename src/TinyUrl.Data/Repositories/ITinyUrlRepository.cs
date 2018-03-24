using System.Threading;
using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public interface ITinyUrlRepository : IRepository<int, Url>
    {
        /// <summary>
        /// Get URL with specified hash.
        /// </summary>
        /// <param name="hash">URL hash.</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        /// <returns>URL that corresponds to the given hash otherwise null.</returns>
        ValueTask<string> GetByHashAsync(string hash, CancellationToken cancellationToken = default);
    }
}
