using System;
using System.Collections.Generic;
using System.Text;

namespace TinyUrl.Data.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
