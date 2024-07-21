using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace yourlook.Controllers
{
    public class AccessController : Controller
    {
        YourlookContext db = new YourlookContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public IActionResult Login(DbKhachHang user) 
        {
            if (HttpContext.Session.GetString("user") == null)
            { 
                var i=db.DbKhachHangs.Where(x=>x.Email.Equals(user.Email) && x.Passwords.Equals(user.Passwords)).FirstOrDefault();
                if (i !=null)
                {
                    HttpContext.Session.SetString("user",i.Email.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không chính xác.");
                }
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(DbKhachHang user )
        {
            if (ModelState.IsValid) 
            { 
                var emailexit=db.DbKhachHangs.FirstOrDefault(x=>x.Email == user.Email);
                if (emailexit != null) 
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng.");
                    return View(user);
                }  
                user.CreateDate = DateTime.Now;
                db.DbKhachHangs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Access");
            }
            return View(user);
        }
        public IActionResult LogOut() 
        {

            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
		}
    }
}
