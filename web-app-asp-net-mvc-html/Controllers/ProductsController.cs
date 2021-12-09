using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_html.Models;

namespace web_app_asp_net_mvc_html.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Size).Include(p => p.Tag);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "SizeName");
            ViewBag.TagId = new SelectList(db.Tags, "Id", "TagName");
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,SizeId,BrandId,Description,Color,TagId,ImagePath,Price")] Product product, HttpPostedFileBase ImageFile)
        {
            
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "SizeName", product.SizeId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "TagName", product.TagId);

            string fileName = Path.GetFileName(ImageFile.FileName);
            ImageFile.SaveAs(Server.MapPath($"~/Image/{fileName}"));
            product.ImagePath = $"/Image/{fileName}";
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "SizeName", product.SizeId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "TagName", product.TagId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,SizeId,BrandId,Description,Color,TagId,ImagePath,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", product.BrandId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "SizeName", product.SizeId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "TagName", product.TagId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            if (product.ImagePath != null)
            {
                System.IO.File.Delete(Server.MapPath("~"+product.ImagePath.ToString()) );
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
