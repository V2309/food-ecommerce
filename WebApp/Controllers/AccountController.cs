using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Net;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogoutAdmin()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }
        // dang nhap
        [HttpPost]
        public ActionResult Login(UserModel model)
        {        
            using (ProductDBContext context = new ProductDBContext())
            {
                var userRoleProvider = new UsersRoleProvider();
                model.matkhau = GetMD5(model.matkhau);
               
                var usercheck = context.User_Web.SingleOrDefault(x => x.ten_taikhoan.Equals(model.ten_taikhoan));
                bool IsValidUser = context.User_Web.Any(user => user.ten_taikhoan.ToLower() ==
                model.ten_taikhoan.ToLower() && user.matkhau == model.matkhau);
                if (IsValidUser)
                {
                    // lay thuoc tinh hoten trong bang user_web 
                    Session["User_Web"] = usercheck;
                    // kiem tra dang nhap 
                    if (usercheck.ten_taikhoan=="Admin" || usercheck.ten_taikhoan == "User" || usercheck.ten_taikhoan == "Customer")
                    {
                        FormsAuthentication.SetAuthCookie(model.ten_taikhoan, false);
                        return RedirectToAction("Dashboard", "AdminPage");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.ten_taikhoan, false);
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                ViewBag.LoginFail = "Tài khoản hoặc mật khẩu không hợp lệ! Vui lòng thử lại!";
                return View();
            }
        }      
       public ActionResult Register()
        {
            return View();
        }
        // dang ky tai khoan 
        [HttpPost]
        public ActionResult Register(User_Web model)
        {
            using(ProductDBContext context = new ProductDBContext())
            {
                bool IsValidUser = context.User_Web.Any(user => user.ten_taikhoan.ToLower() == model.ten_taikhoan);
                if (!IsValidUser)
                {
                    model.matkhau = GetMD5(model.matkhau);
                    context.User_Web.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Login");
                }
                ViewBag.SignupFail = " Tên tài khoản đã có! Vui lòng thử lại!";

            }
            return View();

        }
        
        public ActionResult Logout()
        {
            Session["User_Web"] = null;
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Index", "Home");
        }
        
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2string = null;
            for (int i = 0; i < targetData.Length; i++){
                byte2string += targetData[i].ToString("x2");
            }
            return byte2string;
        }


    }

}
