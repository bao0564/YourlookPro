using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace yourlook.Areas.Admin.Controllers
{
	[Area("admin")]
	[Route("admin")]
	public class KhachhangController : Controller
	{
		YourlookContext db = new YourlookContext();
		[Route("khachhang")]
		public IActionResult KhachHang(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
            int pageSize = 10;
			int pageNumber = page ?? 1;
			var lstKhachHang = db.DbKhachHangs.AsNoTracking().OrderBy(x => x.MaKh).ToList();
			PagedList<DbKhachHang> lst = new PagedList<DbKhachHang>(lstKhachHang, pageNumber, pageSize);
			return View(lst);
		}
		[Route("xoakhachhang")]
		[HttpGet]
		public IActionResult XoaKhachHang(int makh)
		{
            TempData["Message"] = "";
            var user=db.DbKhachHangs.Find(makh);
			if (user != null) 
			{ 
				db.DbKhachHangs.Remove(user);
				db.SaveChanges();
			}
            TempData["Message"] = "Đã xóa tài khoản này";
            return RedirectToAction("khachhang");
		}
	}
}
