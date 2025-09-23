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
    public class AdminPageController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        // GET: AdminPage
        [Authorize(Roles = "Admin , User, Customer")]
        public ActionResult DSDonHang()
        {
            List<TheOrder> lists = db.TheOrders.Include(order => order.OrderDetails).ToList();
            return View(lists);
        }

        [Authorize(Roles = "Admin , User, Customer")]

        public ActionResult Dashboard()
        {
            List<ProductInfo> list = db.ProductInfoes.ToList();
            return View(list);
        }


        [Authorize(Roles = "Admin , User, Customer")]
        public ActionResult DSSanPham(String searching, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            List<ProductInfo> lists = db.ProductInfoes.ToList();
            return View(db.ProductInfoes.Where(x => x.ten_sanpham.Contains(searching) || searching == null).ToList()
                                                                                    .ToPagedList(pageNumber, pageSize));
        }
        [Authorize(Roles = "Admin , User, Customer")]
        public ActionResult DSBaiViet()
        {
            List<Blog> lists = db.Blogs.ToList();
            return View(lists);
        }
    }
}