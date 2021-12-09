using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_html.Models
{
    public class Size
    {
        [Display(Name = "Размер")]
        public int Id { get; set; }

        [Display(Name = "Размер")]
        public string SizeName { get; set; }

        
    }
}