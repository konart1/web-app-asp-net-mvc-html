using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_html.Models;

namespace web_app_asp_net_mvc_html.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db = new ShopContext();
        
        public ActionResult Index()
        {
            var products = db.Products;
            return View(products);
        }

        public ActionResult Thing(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}