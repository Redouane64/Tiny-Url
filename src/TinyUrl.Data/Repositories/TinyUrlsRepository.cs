using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public class TinyUrlsRepository : IUrlsRepository, IDisposable
    {
        private readonly TinyUrlContext context;

        public TinyUrlsRepository(TinyUrlContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Url entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Url> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddUrlAsync(Url url)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Url entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Url> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose() => context.Dispose();

        public ValueTask<IEnumerable<Url>> FindAsync(Expression<Func<Url, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Url>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Url> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Url> GetByOriginalUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Url> GetByShortUrl(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Url entity)
        {
            throw new NotImplementedException();
        }
    }
}
