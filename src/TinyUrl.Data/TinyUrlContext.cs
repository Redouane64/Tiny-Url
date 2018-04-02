using System;
using Microsoft.EntityFrameworkCore;
using TinyUrl.Data.Models;

namespace TinyUrl.Data
{
    public class TinyUrlContext : DbContext
    {
        public TinyUrlContext(DbContextOptions<TinyUrlContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}
