using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace yourlook.Controllers
{
    public class AccessController : Controller
    {
        YourlookContext db = new YourlookContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("email") == null)
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
            if (HttpContext.Session.GetString("email") == null)
            { 
                var i=db.DbKhachHangs.Where(x=>x.Email.Equals(user.Email) && x.Passwords.Equals(user.Passwords)).FirstOrDefault();
                if (i !=null)
                {
                    HttpContext.Session.SetString("email",i.Email.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
