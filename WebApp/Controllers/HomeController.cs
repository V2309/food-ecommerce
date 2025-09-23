using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApp.Models;
using PagedList;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;
namespace WebApp.Controllers
{
    // phan trang  va tim kiem san pham
    public class HomeController :Controller
    {
        private ProductDBContext dbcontext = new ProductDBContext();
        public ActionResult Index ( string searching , int? page)
        {
                
                var pageNumber = page ?? 1;
                var pageSize = 10;
                List<ProductInfo> lists = dbcontext.ProductInfoes.ToList();
                return View(dbcontext.ProductInfoes.Where(x=> x.ten_sanpham.Contains(searching)|| searching==null).ToList()
                                                                                        .ToPagedList(pageNumber , pageSize));

            

        }
     
        public ActionResult About ()
        {
            return View();
        }
     

        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Blog()
        {
            List<Blog> lists = dbcontext.Blogs.ToList();
            return View(lists);
        }

       
    
}
}


