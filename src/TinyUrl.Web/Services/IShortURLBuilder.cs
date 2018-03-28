using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUrl.Web.Services
{
    public interface IShortURLBuilder
    {
        string CreateShortURLFromHash(string hash);
    }

    public class DefaultShortURLBuilder : IShortURLBuilder
    {
        private readonly HttpContext context;

        public DefaultShortURLBuilder(IHttpContextAccessor httpContextAccessor)
        {
            context = httpContextAccessor.HttpContext;
        }

        public DefaultShortURLBuilder(HttpContext context)
        {
            this.context = context;
        }

        public string CreateShortURLFromHash(string hash) => $"{Uri.UriSchemeHttp}://{context.Request.Host}/{hash}";
    }
}
