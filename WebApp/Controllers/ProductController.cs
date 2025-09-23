using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApp.Models;
namespace WebApp.Controllers

{
    public class ProductController : Controller
    {

        public ActionResult ProductCategory(String idnhom = "ca")
        {
            ProductDBContext dbcontext = new ProductDBContext();
 
            List<ProductInfo> lists = dbcontext.ProductInfoes
                                    .Include(gr=> gr.Product_Group)
                                    .Where(pro => pro.id_nhomsp == idnhom).ToList();
            var namepro = dbcontext.Product_Group.SingleOrDefault(x => x.id_nhomsp.Equals(idnhom));
            Session["Product_Group"] =namepro;
            return View(lists);
          
        }
        public ActionResult ProductDetail(int id)
        {
            ProductDBContext dBContext = new ProductDBContext();
           
            ProductInfo product = dBContext.ProductInfoes.Include(gr => gr.Product_Group).FirstOrDefault(x => x.id_sanpham == id);
   
            return View(product);

        }

    }

}