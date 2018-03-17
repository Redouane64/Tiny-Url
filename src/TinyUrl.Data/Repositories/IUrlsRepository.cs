using System.Threading.Tasks;
using RepositoryBase;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public interface IUrlsRepository : IRepository<Url>
    {
        Task AddUrlAsync(Url url);
        ValueTask<Url> GetByOriginalUrlAsync(string url);
        ValueTask<Url> GetByShortUrl(string shortUrl);
    }
}
