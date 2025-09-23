using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.IO;
using PagedList;
namespace WebApp.Controllers
{
    public class CrudController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        
        // GET: Admmin
       [Authorize(Roles = "Admin , User, Customer")]
        public ActionResult Details(int id)
        {
            ProductInfo product = db.ProductInfoes.Include(gr => gr.Product_Group).FirstOrDefault(x => x.id_sanpham == id);
            return View(product);


        }
        // get product:create
        [Authorize(Roles = "Admin , User")]
        public ActionResult Create()
        {
            return View();
        }

        
        [Authorize(Roles = "Admin")]
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sanpham ,ten_sanpham,id_loai_sanpham, hinh_sanpham ,giacu,giamoi ,hinh_quatang, thongtin_km ,thongtin_soluong, id_nhomsp")] ProductInfo product ,HttpPostedFileBase imgfile)
        {
            if (ModelState.IsValid)
            {
                product.hinh_sanpham = FileUpLoad(imgfile);
                db.ProductInfoes.Add(product);
                db.SaveChanges();
                return RedirectToAction("DSSanPham", "AdminPage");
            }
            ViewBag.CatId = new SelectList(db.Pro_Category, "id_loai_sanpham", "tenloaisp", product.id_loai_sanpham);

            return View(product);
        }
        //  ham file upload
        public  string FileUpLoad( HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/images/Products/");
            string filename = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(path, filename);
            file.SaveAs(fullPath);
            return filename;
        }
     

        //get edit 
        [Authorize(Roles = "Admin , User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = db.ProductInfoes.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);   
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sanpham,ten_sanpham,id_loai_sanpham, hinh_sanpham ,giacu,giamoi ,hinh_quatang, thongtin_km ,thongtin_soluong, id_nhomsp")] ProductInfo product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSSanPham" , "AdminPage");
            }          
            return View(product);
        }
        // get delete 
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            ProductInfo product = db.ProductInfoes.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductInfo product = db.ProductInfoes.Find(id);
            db.ProductInfoes.Remove(product);
            db.SaveChanges();
            return RedirectToAction("DSSanPham", "AdminPage");

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
