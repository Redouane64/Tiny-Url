using System.Threading.Tasks;
using RepositoryBase;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public interface IUrlsRepository : IRepository<Url>
    {
        ValueTask<string> GetByHashAsync(string urlHash);
    }
}
