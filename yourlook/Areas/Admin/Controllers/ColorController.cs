using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class ColorController : Controller
    {
        YourlookContext db=new YourlookContext();
        [Route("color")]
        public IActionResult Color(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var lstColor=db.DbColors.AsNoTracking().OrderBy(x=>x.CreateDate).ToList();
            PagedList<DbColor> lst = new PagedList<DbColor>(lstColor,pageNumber, pageSize);
            return View(lst);
        }
        [Route("taocolor")]
        [HttpGet]
        public IActionResult TaoColor()
        {
            return View();
        }
        [Route("taocolor")]
        [HttpPost]
        public IActionResult TaoColor(DbColor color)
        {
            return View();
        }
        [Route("suacolor")]
        [HttpGet]
        public IActionResult SuaColor(int colorid)
        {
            return View();
        }
        [Route("suacolor")]
        [HttpPost]
        public IActionResult SuaColor(DbColor color)
        {
            return View();
        }
        [Route("xoacolor")]
        [HttpGet]
        public IActionResult XoaColor(int colorid)
        {
            TempData["Message"] = "";
            var sp= db.DbChiTietSanPhams.Any(x=>x.MaMau==colorid);
            if (sp)
            {
                TempData["Message"] = "Màu đã được sử dụng nên không thể xóa";
                return RedirectToAction("Index");
            }
            var color=db.DbColors.Find(colorid);
            if (color !=null)
            {                
                db.DbColors.Remove(color);
                db.SaveChanges();
            }
            TempData["Message"] = "Màu ĐÃ ĐƯỢC XÓA";
            return RedirectToAction("Index");
        }
    }
}
