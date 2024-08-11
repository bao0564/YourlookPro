using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (HttpContext.Session.GetString("user") == null && HttpContext.Session.GetInt32("userid") ==null)
            { 
                var i=db.DbKhachHangs.Where(x=>x.Email.Equals(user.Email) && (x.Passwords.Equals(user.Passwords)|| x.IsExternalAccount)).FirstOrDefault();
                if (i !=null)
                {
                    HttpContext.Session.SetString("user",i.Email.ToString());
                    HttpContext.Session.SetInt32("userid",i.MaKh);
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
                user.IsExternalAccount = false;
                db.DbKhachHangs.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Access");
            }
            return View(user);
        }
        //đăng ký bằng gg
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Access", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return RedirectToAction(nameof(Login));
            }

            var info = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (info?.Principal == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var name = info.Principal.FindFirstValue(ClaimTypes.Name);

            if (email == null)
            {
                ModelState.AddModelError(string.Empty, "Email not received from external provider.");
                return RedirectToAction(nameof(Login));
            }

            var user = db.DbKhachHangs.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                user = new DbKhachHang
                {
                    Email = email,
                    TenKh = name,
                    IsExternalAccount=true,
                    CreateDate = DateTime.Now
                };
                db.DbKhachHangs.Add(user);
                db.SaveChanges();
            }

            HttpContext.Session.SetString("user", user.Email);
            HttpContext.Session.SetInt32("userid", user.MaKh);

            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public IActionResult LogOut() 
        {

            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
		}
    }
}
