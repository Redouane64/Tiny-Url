using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TinyUrl.Web.Pages
{
    public class ShortURLModel : PageModel
    {
        public string ShortURL { get; set; }
        public void OnGet(string shortURL)
        {
            ShortURL = shortURL;
        }
    }
}