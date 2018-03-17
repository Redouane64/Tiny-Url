using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Url entity)
        {
            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddRangeAsync(IEnumerable<Url> entities)
        {
            try
            {
                await context.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        public async ValueTask<Url> GetAsync(int id)
        {
            try
            {
                return await context.FindAsync<Url>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async ValueTask<Url> GetByOriginalUrlAsync(string url)
        {
            try
            {
                return await context.Urls.FirstOrDefaultAsync(u => u.OriginalUrl.Equals(url, StringComparison.Ordinal));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async ValueTask<Url> GetByShortUrl(string shortUrl)
        {
            try
            {
                return await context.Urls.FirstOrDefaultAsync(u => u.OriginalUrl.Equals(shortUrl, StringComparison.Ordinal));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task UpdateAsync(Url entity)
        {
            throw new NotImplementedException();
        }
    }
}
