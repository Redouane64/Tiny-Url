using System;
using Microsoft.EntityFrameworkCore;
using TinyUrl.Data;
using TinyUrl.Data.Repositories;
using Xunit;

namespace TinyUrl.Services.Tests
{
    public class DefaultUrlSherteningServiceTests : IDisposable
    {
        private readonly TinyUrlsRepository repository;

        public DefaultUrlSherteningServiceTests()
        {
            var options = new DbContextOptionsBuilder<TinyUrlContext>()
                            .UseInMemoryDatabase("test-database")
                            .Options;
            var context = new TinyUrlContext(options);
            repository = new TinyUrlsRepository(context);
        }

        public void Dispose() => repository.Dispose();

        [Fact]
        public void DoesCreateShortURL()
        {

            var service = new DefaultUrlShorteningService(repository);
            var testUrl = "https://github.com/aspnet/KestrelHttpServer";

            var shortUrl = service.CreateShortURLAsync(testUrl).Result;

            Assert.NotNull(shortUrl);
        }
    }
}
