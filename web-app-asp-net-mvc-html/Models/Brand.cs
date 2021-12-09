using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_html.Models
{
    public class Brand
    {
        [Display(Name = "Бренд")]
        public int Id { get; set; }

        [Display(Name = "Бренд")]
        public string BrandName { get; set; }
    }
}