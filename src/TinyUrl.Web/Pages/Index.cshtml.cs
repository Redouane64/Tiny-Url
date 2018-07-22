using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyUrl.Data.Repositories;
using TinyUrl.Services;

namespace TinyUrl.Web.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IUrlShorteningService shorteningService;
        private readonly ITinyUrlRepository repository;

        public IndexModel(
            IUrlShorteningService shorteningService,
            ITinyUrlRepository repository)
        {
            this.shorteningService = shorteningService;
            this.repository = repository;
        }

        [BindProperty(Name = "url")]
        public string URL { get; set; }

        public string ShortURL { get; set; }

        public async Task<IActionResult> OnGet([FromRoute]string hash)
        {
            if (!String.IsNullOrEmpty(hash))
            {
                var url = await repository.GetURLByShortHash(hash);
                if(url != null)
                {
                    return RedirectPermanent(url);
                }
                else
                {
                    return RedirectToPage("NotFound");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Shorten URL.
            var hash = await shorteningService.CreateShortURLAsync(URL);
            ShortURL = $"{Uri.UriSchemeHttp}://{HttpContext.Request.Host}/{hash}";

            return RedirectToPagePermanent("ShortURL", nameof(ShortURLModel.OnGet), new { shortURL = ShortURL });
        }
    }
}
