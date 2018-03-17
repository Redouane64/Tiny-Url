using System.Threading.Tasks;
using RepositoryBase;
using TinyUrl.Data.Models;

namespace TinyUrl.Services
{
    public interface IUrlsRepository : IRepository<Url>
    {
        Task AddAsync(Url url);
        Task<Url> GetByIdAsync(int id);
    }
}