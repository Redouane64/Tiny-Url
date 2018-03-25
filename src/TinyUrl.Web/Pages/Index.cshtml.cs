﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TinyUrl.Web.Pages
{
    public class IndexModel : PageModel
    {
        [FromBody]
        public URLViewModel Model { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            // TODO : Catch URL here.

            await Task.CompletedTask;
        }
    }
}