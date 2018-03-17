using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase;
using TinyUrl.Data;
using TinyUrl.Data.Models;

namespace TinyUrl.Services
{
    public class TinyUrlService : IUrlsRepository
    {
        private readonly TinyUrlContext context;
        private readonly IUrlShorteningService urlShorteningService;

        public TinyUrlService(
            TinyUrlContext context,
            IUrlShorteningService urlShorteningService)
        {
            this.context = context;
            this.urlShorteningService = urlShorteningService;
        }

        Task IUrlsRepository.AddAsync(Url url) => throw new NotImplementedException();
        Task<Url> IUrlsRepository.GetByIdAsync(int id) => throw new NotImplementedException();

        void IRepository<Url>.Add(Url entity) => throw new NotImplementedException();
        void IRepository<Url>.AddRange(IEnumerable<Url> entities) => throw new NotImplementedException();
        void IRepository<Url>.Delete(Url entity) => throw new NotImplementedException();
        IEnumerable<Url> IRepository<Url>.Find(Expression<Func<Url, bool>> predicate) => throw new NotImplementedException();
        Url IRepository<Url>.Get(int id) => throw new NotImplementedException();
        IEnumerable<Url> IRepository<Url>.GetAll() => throw new NotImplementedException();
        void IRepository<Url>.Update(Url entity) => throw new NotImplementedException();
    }
}
