using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        
        private ProductDBContext dbContext = new ProductDBContext();
        private string strCart = "Carts";

        // GET: ShoppingCart

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderNow(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            if (Session[strCart] ==null)
            {
                List<Carts> listCart = new List<Carts>
                {
                    new Carts(dbContext.ProductInfoes.Find(id), 1)
                };
                Session[strCart] = listCart;

            }
            else
            {
                List<Carts> listcart = (List<Carts>)Session[strCart];
                int check = IsExistingCheck(id);
                if (check == -1)
                    listcart.Add(new Carts(dbContext.ProductInfoes.Find(id), 1));
                else
                    listcart[check].Quantity++;
                Session[strCart] = listcart;
            }
            return RedirectToAction("Index");
            
        }
        private int IsExistingCheck(int? id)
        {
            List<Carts> listcart = (List<Carts>)Session[strCart];
            for (int i = 0; i<listcart.Count;i++)
            {
                if (listcart[i].Product.id_sanpham==id)
                    return i;
            }
            return -1;
        }
        public ActionResult RemoveItem (int ? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = IsExistingCheck(id);
            List<Carts> listcart = (List<Carts>)Session[strCart];
            listcart.RemoveAt(check);
            if(listcart.Count==0) 
            {
                Session[strCart] = null;
            }
            else
            {
                Session[strCart] = listcart;
            }
            return RedirectToAction("Index");
          
            
        }
        [HttpPost]
        public ActionResult UpdateCart(FormCollection field)
        {
            string[] quantites = field.GetValues("soluong");
            List<Carts> listcart = (List < Carts > ) Session[strCart];
       
            for (int i = 0; i<listcart.Count; i++)
            {
                int newQuantity = Convert.ToInt32(quantites[i]);
                var product = dbContext.ProductInfoes.Find(listcart[i].Product.id_sanpham);
                if (newQuantity > product.soluong)
                {
                    // Nếu số lượng không đủ, thông báo lỗi và không cập nhật số lượng
                    ViewBag.Error = $"Sản phẩm {product.ten_sanpham} không đủ số lượng. Chỉ còn {product.soluong} sản phẩm có sẵn.";
                    return View("Index", listcart); // Trả về view cùng với thông báo lỗi
                }
                listcart[i].Quantity = Convert.ToInt32(quantites[i]);

            }
            
            Session[strCart] = listcart;
            return RedirectToAction("Index");
        }
        public ActionResult ClearCart()
        {
            Session[strCart] = null;
            return RedirectToAction("Index");
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
       public ActionResult ProcessOrder(FormCollection field)
        {
            List<Carts> listcart = (List<Carts>)Session[strCart];
            // save the order into order table 
            int numberOfOrders = dbContext.TheOrders.Count();
            var order = new WebApp.Models.TheOrder()
            {
                tendondang = "Đơn hàng" + " " + (numberOfOrders + 1),
                tenkhachhang = field["cusName"],
                sdt = field["cusPhone"],
                email =field["cusEmail"],
                diachi = field["cusAddress"],
                ngay = DateTime.Now,
                hinhthuc_thanhtoan = "Cash",
                Statuss = "Processing"
            };
            dbContext.TheOrders.Add(order);
            dbContext.SaveChanges();
            // save the order detail in to order detail table
            foreach(Carts carts in listcart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    id_donhang = order.id_donhang,
                    id_sanpham= carts.Product.id_sanpham,
                    soluong  = Convert.ToInt32(carts.Quantity),
                    thanhtien = Convert.ToDouble(carts.Product.giamoi)
                };
                dbContext.OrderDetails.Add(orderDetail);
                dbContext.SaveChanges();
            }
            // removing shoping cart
            Session.Remove(strCart);
            return View("OrderSuccess");

         

          
        }


        public ActionResult OrderSuccess()
        {
            return View();
        }



    }
}