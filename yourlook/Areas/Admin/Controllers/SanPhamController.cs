
using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using yourlook.Controllers;
using yourlook.Models;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class SanPhamController : Controller
    {
        YourlookContext db = new YourlookContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SanPhamController> _logger;

        public SanPhamController(YourlookContext context, IWebHostEnvironment webHostEnvironment, ILogger<SanPhamController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        //Sản Phẩm
        [Route("sanpham")]
        public IActionResult SanPham(int? page)
        {
            int pageSize = 20;
            int pageNumber = page ?? 1;
            var lstSanPham = db.DbSanPhams.Include(p => p.MaDanhMucsMaDm).OrderByDescending(x => x.CreateDate).ToList();
            PagedList<DbSanPham> lst = new PagedList<DbSanPham>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
        //Thêm Sản Phẩm
        [Route("taosanpham")]
        [HttpGet]
        public IActionResult TaoSanPham()
        {
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            return View();
        }
        [Route("taosanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaoSanPham(DbSanPham sanPham, string Imgs,IFormFile AnhSpFile)
        {
            if (ModelState.IsValid)
            {
                sanPham.CreateDate = DateTime.Now;

                // xử lý tải ảnh đại diện
                if (AnhSpFile != null && AnhSpFile.Length > 0)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(AnhSpFile.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await AnhSpFile.CopyToAsync(fileStream);
                    }

                    sanPham.AnhSp = "" + fileName;
                }

                // Thêm sản phẩm vào cơ sở dữ liệu
                db.DbSanPhams.Add(sanPham);
                await db.SaveChangesAsync();

                if (!string.IsNullOrEmpty(Imgs))
                {
                    string[] imagePaths = Imgs.Split(';');
                    foreach (var imagePath in imagePaths)
                    {
                        db.DbImgs.Add(new DbImg
                        {
                            MaSp = sanPham.MaSp,
                            Img = imagePath
                        });
                    }
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("SanPham");
            }

            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            return View(sanPham);
        }
        [Route("suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(int masp)
        {
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            var sanPham = db.DbSanPhams.Include(sp => sp.DbImgs).FirstOrDefault(sp => sp.MaSp == masp);
            return View(sanPham);
        }
        [Route("suasanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaSanPham(DbSanPham sanPham, string Imgs, IFormFile AnhSpFile)
        {
            if (ModelState.IsValid)
            {
                sanPham.ModifiedDate = DateTime.Now;
                db.DbSanPhams.Attach(sanPham);
                db.Entry(sanPham).State = EntityState.Modified;

                if (AnhSpFile !=null && AnhSpFile.Length >0)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(AnhSpFile.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await AnhSpFile.CopyToAsync(fileStream);
                    }

                    sanPham.AnhSp = "" + fileName;
                }
                if (!string.IsNullOrEmpty(Imgs))
                {
                    string[] imagePaths = Imgs.Split(';');
                    foreach (var imagePath in imagePaths)
                    {
                        db.DbImgs.Add(new DbImg
                        {
                            MaSp = sanPham.MaSp,
                            Img = imagePath
                        });
                    }
                    await db.SaveChangesAsync();
                }
                await db.SaveChangesAsync();
                return RedirectToAction("SanPham");
            }

            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            return View(sanPham);
        }
        // Xóa Sản Phẩm
        [Route("xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham(int masp)
        {
            TempData["Message"] = "";
            db.Remove(db.DbSanPhams.Find(masp));
            db.SaveChanges();
            TempData["Message"] = "Sản Phẩm Đã Được Xóa";
            return RedirectToAction("sanpham");
        }
        [HttpPost]
        public async Task<IActionResult> UploadImg(List<IFormFile> files)
        {
            var filePaths = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    filePaths.Add("/img/" + fileName);
                }
            }

            return Json(new { success = true, filePaths });
        }

    }
}