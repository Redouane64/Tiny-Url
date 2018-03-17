using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Services
{
    public interface IUrlShorteningService
    {
        Task<string> GetShortUrl(Url url);
    }
}
