using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class GroupController : Controller
    {
        YourlookContext db = new YourlookContext();

        [Route("group")]
        public IActionResult Group(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
            int pageSize = 5;
            int pageNumber=page ?? 1;
            var listGroup = db.DbGroups.AsNoTracking().OrderBy(x => x.NhomId);
            PagedList<DbGroup> lst= new PagedList<DbGroup>(listGroup,pageNumber,pageSize);
            return View(lst);
        }
        [Route("taonhom")]
        [HttpGet]
        public IActionResult TaoNhom() 
        { 
            return View();
        }
        [Route("taonhom")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaoNhom(DbGroup nhom) 
        { 
            if (ModelState.IsValid)
            {
                nhom.CreateDate= DateTime.Now;
                db.DbGroups.Add(nhom);
                db.SaveChanges();
                return RedirectToAction("Group");
            }
            return View(nhom);
        }
    }
}
