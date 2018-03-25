using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUrl.Web
{
    public class URLViewModel
    {
        [Required]
        [DataType(DataType.Url)]
        public string URL { get; set; }
    }
}
