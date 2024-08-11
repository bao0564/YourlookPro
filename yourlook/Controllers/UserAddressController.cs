using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace yourlook.Controllers
{
	public class UserAddressController : Controller
	{
		YourlookContext db= new YourlookContext();           
        [HttpGet]
        public IActionResult UserAddress()
        {
			var idkh = HttpContext.Session.GetInt32("userid");
            if (idkh==null)
            {
                return RedirectToAction("Login", "Access");
            }
            var adress=db.DbAddreses.Where(X=>X.MaKh==idkh.Value).ToList();
            return View(adress);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DbAddres address)
        {
            var idkh = HttpContext.Session.GetInt32("userid"); 
            if (ModelState.IsValid) 
            { 
                address.MaKh = idkh.Value;
                address.CreateDate = DateTime.Now;
                db.DbAddreses.Add(address);
                db.SaveChanges();
                return RedirectToAction("UserAddress", "UserAddress");
            }
            return View(address);
        }

        [HttpGet]
        public IActionResult Edit(int idaddress)
        {
            var address = db.DbAddreses.Find(idaddress);
            var idkh = HttpContext.Session.GetInt32("userid");
            if (address == null || address.MaKh != idkh.Value)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        public IActionResult Edit(DbAddres address)
        {
            if (ModelState.IsValid)
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                db.DbAddreses.Attach(address);
                address.ModifiedDate = DateTime.Now;
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserAddress");
            }
            return View(address);
        }

        [HttpPost]
        public IActionResult Delete(int idaddress)
        {
            var address = db.DbAddreses.Find(idaddress);
            if (address != null)
            {
                db.DbAddreses.Remove(address);
                db.SaveChanges();
            }
            return RedirectToAction("UserAddress", "UserAddress");
        }
    }
}
