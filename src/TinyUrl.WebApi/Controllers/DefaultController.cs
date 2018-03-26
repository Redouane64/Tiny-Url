using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyUrl.Data.Repositories;
using TinyUrl.Services;

namespace TinyUrl.WebApi.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {

        private readonly IUrlShorteningService urlsService;
        private readonly ITinyUrlRepository repository;

        public DefaultController(
            IUrlShorteningService urlsService,
            ITinyUrlRepository tinyUrlRepository)
        {
            this.urlsService = urlsService;
            this.repository = tinyUrlRepository;
        }

        [HttpGet("{hash}", Name = nameof(Get))]
        public async ValueTask<IActionResult> Get(
            [FromRoute]string hash = null,
            CancellationToken cancellationToken = default)
        {
            if (String.IsNullOrEmpty(hash))
            {
                return BadRequest();
            }

            // Get URL.
            var url = await repository.GetURLByShortHash(hash, cancellationToken);

            if (String.IsNullOrEmpty(url))
            {
                return NotFound();
            }

            // TODO: Increament visit count

            return RedirectPermanent(url);
        }
    }
}