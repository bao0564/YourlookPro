using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace yourlook.Areas.Admin.Controllers
{
	[Area("admin")]
	[Route("admin")]
	public class SizeController : Controller
	{
		YourlookContext db=new YourlookContext();
		[Route("size")]
		[HttpGet]
		public IActionResult Size()
		{
			var lst = db.DbSizes.AsNoTracking().OrderBy(x => x.SizeId);
			return View(lst);
		}
		[Route("taosize")]
		[HttpGet]
		public IActionResult TaoSize()
		{
			return View();
		}
		[Route("taosize")]
		[HttpPost]
		public IActionResult TaoSize(DbSize size)
		{
			if(ModelState.IsValid)
			{
				size.CreateDate = DateTime.Now;
				db.DbSizes.Add(size);
				db.SaveChanges();
				return RedirectToAction("Size");
			}
			return View(size);
		}
		[Route("suasize")]
		[HttpGet]
		public IActionResult SuaSize(int idsize)
		{
			var Size=db.DbSizes.Find(idsize);
			return View(Size);
        }
        [Route("suasize")]
        [HttpPost]
        public IActionResult SuaSize(DbSize size)
        {
			if (ModelState.IsValid)
			{
				db.DbSizes.Attach(size);
				size.ModifiedDate = DateTime.Now;
				db.Entry(size).State= EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Size");
			}
            return View(size);
        }
		[Route("xoasize")]
		[HttpGet]
		public IActionResult XoaSize(int idsize)
		{
			TempData["Message"] = "";
			var sp=db.DbChiTietSanPhams.Any(x=>x.SizeId==idsize);
			if(sp)
            {
                TempData["Message"] = "Size ĐÃ CÓ SẢN PHẨM DÙNG - KHÔNG THỂ XÓA";
				return RedirectToAction("Size");
			}
			var size = db.DbSizes.Find(idsize);
			if (size!=null)
			{
                db.DbSizes.Remove(size);
                db.SaveChanges();
            }
            TempData["Message"] = "Size ĐÃ ĐƯỢC XÓA";
            return RedirectToAction("Size");
		}
    }
}
