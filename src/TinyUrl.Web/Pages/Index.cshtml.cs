using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyUrl.Services;
using TinyUrl.Web.Services;

namespace TinyUrl.Web.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IUrlShorteningService shorteningService;
        private readonly IShortURLBuilder shortURLBuilder;

        public IndexModel(
            IUrlShorteningService shorteningService
            /*IShortURLBuilder shortURLBuilder*/)
        {
            this.shorteningService = shorteningService;
            //this.shortURLBuilder = shortURLBuilder;
            this.shortURLBuilder = new DefaultShortURLBuilder(HttpContext);
        }

        [BindProperty(Name = "url")]
        public string URL { get; set; }

        public string ShortURL { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            // Shorten URL.
            var hash = await shorteningService.CreateShortURLAsync(URL);
            ShortURL = $"{Uri.UriSchemeHttp}://{HttpContext.Request.Host}/{hash}"; //shortURLBuilder.CreateShortURLFromHash(hash);
        }
    }
}
