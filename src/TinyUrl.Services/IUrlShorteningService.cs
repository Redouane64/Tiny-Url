using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Services
{
    public interface IUrlShorteningService
    {
        Task<string> GetShortUrl(string url);
    }
}
