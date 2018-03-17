using TinyUrl.Data.Repositories;

namespace TinyUrl.Services
{
    public class TinyUrlService
    {
        private readonly IUrlsRepository repository;
        private readonly IUrlShorteningService urlShorteningService;

        public TinyUrlService(
            IUrlsRepository repository,
            IUrlShorteningService urlShorteningService)
        {
            this.repository = repository;
            this.urlShorteningService = urlShorteningService;
        }

    }
}
