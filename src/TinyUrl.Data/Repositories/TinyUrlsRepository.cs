﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinyUrl.Data.Models;

namespace TinyUrl.Data.Repositories
{
    public class TinyUrlsRepository : ITinyUrlRepository, IDisposable
    {
        private readonly TinyUrlContext context;

        public TinyUrlsRepository(TinyUrlContext context)
        {
            this.context = context;
        }

        public void Dispose() => context.Dispose();

        public async Task AddAsync(
            Url entity, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                await context.AddAsync(entity, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(
            Expression<Func<Url, bool>> predicate, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await context.Urls.FirstOrDefaultAsync(predicate, cancellationToken);

                if(entity != null)
                {
                    context.Remove(entity);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Url>> FindAsync(
            Expression<Func<Url, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return await context.Urls.Where(predicate).ToListAsync();
        }

        public async Task<Url> GetAsync(
            Expression<Func<Url, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await context.Urls.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> GetByHashAsync(
            string hash,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await context.Urls.Where(u => u.UrlHash == hash)
                                         .Select(u => u.ShortUrl)
                                         .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetURLByShortHash(
            string hash, 
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await context.Urls.Where(
                    u => EF.Functions.Like(u.UrlHash, $"{hash}%"))
                                         .Select(u => u.OriginalUrl)
                                         .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
