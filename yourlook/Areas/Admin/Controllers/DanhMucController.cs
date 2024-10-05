using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using yourlook.MenuKid;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class DanhMucController : Controller
    {
        YourlookContext db = new YourlookContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadPhoto _uploadPhoto;
        public DanhMucController (IUploadPhoto uploadPhoto, IWebHostEnvironment webHostEnvironment)
        {
            _uploadPhoto = uploadPhoto;
            _webHostEnvironment = webHostEnvironment;
        }
        //Danh Mục
        [Route("danhmuc")]
        public IActionResult DanhMuc(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var lstDanhMuc = db.DbDanhMucs.AsNoTracking().OrderByDescending(x => x.MaDm);
            PagedList<DbDanhMuc> lst = new PagedList<DbDanhMuc>(lstDanhMuc, pageNumber, pageSize);
            return View(lst);
        }
        //Thêm Danh Mục
        [Route("taodanhmuc")]
        [HttpGet]
        public IActionResult TaoDanhMuc()
        {
            return View();
        }
        [Route("taodanhmuc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaoDanhMuc(DbDanhMuc danhMuc,IFormFile FileAnh)
        {
            if (ModelState.IsValid)
            {
                if (FileAnh != null && FileAnh.Length > 0)
                {
                    danhMuc.AnhDaiDien = await _uploadPhoto.uploadOnePhotosAsync(FileAnh, "img"); // Chỉ 1 ảnh đại diện
                }
                danhMuc.CreateDate = DateTime.Now;
                db.DbDanhMucs.Add(danhMuc);
                await db.SaveChangesAsync();
                return RedirectToAction("DanhMuc");
            }
            return View(danhMuc);
        }
        //Sửa Danh Mục
        [Route("suadanhmuc")]
        [HttpGet]
        public IActionResult SuaDanhMuc(int madm)
        {
            var DanhMuc = db.DbDanhMucs.Find(madm);
            return View(DanhMuc);
        }
        [Route("suadanhmuc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaDanhMuc(DbDanhMuc danhMuc, IFormFile FileAnh)
		{
            if (ModelState.IsValid)
            {
                if (FileAnh != null && FileAnh.Length > 0)
                {
                    danhMuc.AnhDaiDien = await _uploadPhoto.uploadOnePhotosAsync(FileAnh, "img"); // Chỉ 1 ảnh đại diện
                }
                db.DbDanhMucs.Attach(danhMuc);
                danhMuc.ModifiedDate = DateTime.Now;
                db.Entry(danhMuc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("DanhMuc");
            }
            return View(danhMuc);
        }
        //Xóa Danh Mục
        [Route("xoadanhmuc")]
        [HttpGet]
        public IActionResult XoaDanhMuc(int madm)
        {
            TempData["Message"] = "";
            var sanpham = db.DbSanPhams.Any(x => x.MaDm == madm);
            if (sanpham)
            {
                TempData["Message"] = "DANH MỤC ĐÃ CÓ SẢN PHẨM DÙNG - KHÔNG THỂ XÓA";
                return RedirectToAction("danhmuc");

            }
            var danhmuc = db.DbDanhMucs.Find(madm);
            if (danhmuc != null)
            {
                db.DbDanhMucs.Remove(danhmuc);
                db.SaveChanges();
            }
            TempData["Message"] = "DANH MỤC ĐÃ ĐƯỢC XÓA";
            return RedirectToAction("danhmuc");
        }

    }
}
