using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_html.Models
{
    public class ShopContext:DbContext
    { 
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext () : base("ShopEntity") { }


    }
}