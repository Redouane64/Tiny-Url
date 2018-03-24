using System.Threading;
using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public interface ITinyUrlRepository : IRepository<int, Url>
    {
        ValueTask<string> GetByHashAsync(string hash, CancellationToken cancellationToken = default);
    }
}
