using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]

    public class DonHangController : Controller
    {
        YourlookContext db = new YourlookContext();
        [Route("donhang")]
        public IActionResult DonHang(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var lstDonHang = db.DbDonHangs.AsNoTracking().OrderByDescending(x => x.CreateDate);
            PagedList<DbDonHang> lst = new PagedList<DbDonHang>(lstDonHang, pageNumber, pageSize);
            return View(lst);
        }
        [Route("chitietdonhang")]
        public IActionResult ChiTietDonHang(int madh)
        {
            var DetailDH = db.DbDonHangs.Include(x => x.DbChiTietDonHangs).FirstOrDefault(x => x.MaDh == madh);
            return View(DetailDH);
        }

        //Cập nhật trạng thái đơn hàng 
        [Route("suadonhang")]
        [HttpGet]
        public IActionResult SuaDonHang(int madh)
        {
            var donhang=db.DbDonHangs.Find(madh);
            return View(donhang);
        }
        [Route("suadonhang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaDonHang(DbDonHang Dhang)
        {
            if(ModelState.IsValid)
            {
                Dhang.ModifiedDate= DateTime.Now;
                db.DbDonHangs.Attach(Dhang);
                db.Entry(Dhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DonHang");
            }
            return View(Dhang);
        }
        //Xóa Don Hang
        [Route("xoadonhang")]
        [HttpGet]
        public IActionResult XoaDonHang(int madh)
        {
            var donhang = db.DbDonHangs.Find(madh);
            var chitietdonhang = db.DbChiTietDonHangs.Find(madh);
            if (donhang != null && chitietdonhang != null)
            {
                db.DbDonHangs.Remove(donhang);
                db.DbChiTietDonHangs.Remove(chitietdonhang);
                db.SaveChanges();
            }
            TempData["Message"] = "Đơn Hàng ĐÃ ĐƯỢC XÓA";
            return RedirectToAction("donhang");
        }

    }
}
