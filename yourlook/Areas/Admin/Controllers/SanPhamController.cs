
using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using X.PagedList;
using yourlook.Areas.Admin.Models;
using yourlook.Controllers;
using yourlook.MenuKid;
using yourlook.Models;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class SanPhamController : Controller
    {
        YourlookContext db = new YourlookContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadPhoto _uploadPhoto;
        private readonly ILogger<SanPhamController> _logger;

        public SanPhamController(YourlookContext context,IWebHostEnvironment webHostEnvironment,ILogger<SanPhamController> logger,IUploadPhoto uploadPhoto)
        {
            _uploadPhoto = uploadPhoto;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        //Sản Phẩm
        [Route("sanpham")]
        public IActionResult SanPham(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
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
            var viewModel = new ProductViewModel
            {
                SizeList = db.DbSizes.ToList(),
                ColorList = db.DbColors.ToList()
            };
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            return View(viewModel);
        }
        [Route("taosanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaoSanPham(ProductViewModel sanPham, string Imgs,IFormFile AnhSpFile)
        {
            if (ModelState.IsValid)
            {
				if (AnhSpFile != null && AnhSpFile.Length > 0)
				{
					sanPham.AnhSp = await _uploadPhoto.uploadOnePhotosAsync(AnhSpFile, "img"); // Chỉ 1 ảnh đại diện
				}
				var sp = new DbSanPham
				{
					TenSp = sanPham.TenSp,
					MaDm = sanPham.MaDm,
					NhomId = sanPham.NhomId,
					AnhSp = sanPham.AnhSp,
					SoLuongSp = sanPham.SoLuongSp,
					PriceMax = sanPham.PriceMax,
					GiamGia = sanPham.GiamGia,
					PriceMin = sanPham.PriceMin,
					MotaSp = sanPham.MotaSp,
					CreateDate = DateTime.Now,
					IActive = sanPham.IActive,
					IFavorite = sanPham.IFavorite,
					IFeature = sanPham.IFeature,
					IHot = sanPham.IHot,
					ISale = sanPham.ISale
				};
				db.DbSanPhams.Add(sp);
				await db.SaveChangesAsync();

				// Xử lý hình ảnh liên quan
				if (!string.IsNullOrEmpty(Imgs))
				{
					var imagePaths = Imgs.Split(';');
					foreach (var imagePath in imagePaths)
					{
						db.DbImgs.Add(new DbImg
						{
							MaSp = sp.MaSp, 
							Img = imagePath
						});
					}
					await db.SaveChangesAsync();
				}

				// Xử lý kích thước và màu sắc
				if (sanPham.SelectedSizes != null && sanPham.SelectedColors != null)
				{
					foreach (var size in sanPham.SelectedSizes)
					{
						foreach (var color in sanPham.SelectedColors)
						{
							var spct = new DbChiTietSanPham
							{
								MaSp = sp.MaSp,
								ColorId = color,
								SizeId = size
							};
							db.DbChiTietSanPhams.Add(spct);
						}
					}
					await db.SaveChangesAsync();
				}

				return RedirectToAction("SanPham");
			}
            var viewModel = new ProductViewModel
            {
                SizeList = db.DbSizes.ToList(),
                ColorList = db.DbColors.ToList()
            };
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
            return View(sanPham);
        }
        [Route("suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(int masp)
        {
            var sanPham = db.DbSanPhams.Include(sp => sp.DbImgs)
                .Include(sp=>sp.DbChiTietSanPhams)
                .ThenInclude(sp=>sp.Size)
                .Include(sp=>sp.DbChiTietSanPhams)
                .ThenInclude(sp=>sp.Color)
                .FirstOrDefault(sp => sp.MaSp == masp);

            var viewmodel = new ProductViewModel
            {

                MaSp = sanPham.MaSp,
                TenSp = sanPham.TenSp,
                MaDm = sanPham.MaDm,
                NhomId = sanPham.NhomId,
                AnhSp = sanPham.AnhSp,
                SoLuongSp = sanPham.SoLuongSp,
                PriceMax = sanPham.PriceMax,
                GiamGia = sanPham.GiamGia,
                PriceMin = sanPham.PriceMin,
                MotaSp = sanPham.MotaSp,
                IActive = sanPham.IActive,
                IFavorite = sanPham.IFavorite,
                IFeature = sanPham.IFeature,
                IHot = sanPham.IHot,
                ISale = sanPham.ISale,
                Imgs = sanPham.DbImgs.ToList(),
                SelectedSizes = sanPham.DbChiTietSanPhams.Select(ct => ct.SizeId).ToList(),
                SelectedColors = sanPham.DbChiTietSanPhams.Select(ct => ct.ColorId).ToList(),
                SizeList = db.DbSizes.ToList(),
                ColorList = db.DbColors.ToList()
            };
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm");
            ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName");
			return View(viewmodel);
        }
		[Route("suasanpham")]
		[HttpPost]
		public async Task<IActionResult> SuaSanPham(ProductViewModel sanPham, string Imgs, IFormFile AnhSpFile)
		{
			if (ModelState.IsValid)
			{
				var sp = db.DbSanPhams
					.Include(sp => sp.DbImgs)
					.Include(sp => sp.DbChiTietSanPhams)
						.ThenInclude(ctsp => ctsp.Size)
					.Include(sp => sp.DbChiTietSanPhams)
						.ThenInclude(ctsp => ctsp.Color)
					.FirstOrDefault(sp => sp.MaSp == sanPham.MaSp);
				
				// Xử lý ảnh đại diện
                if (AnhSpFile != null && AnhSpFile.Length > 0)
                {
                    sp.AnhSp = await _uploadPhoto.uploadOnePhotosAsync(AnhSpFile, "img"); // Chỉ 1 ảnh đại diện
                }
				// Cập nhật thông tin sản phẩm
				sp.TenSp = sanPham.TenSp;
				sp.MaDm = sanPham.MaDm;
				sp.NhomId = sanPham.NhomId;
				sp.SoLuongSp = sanPham.SoLuongSp;
				sp.PriceMax = sanPham.PriceMax;
				sp.GiamGia = sanPham.GiamGia;
				sp.PriceMin = sanPham.PriceMin;
				sp.MotaSp = sanPham.MotaSp;
				sp.IActive = sanPham.IActive;
				sp.IFavorite = sanPham.IFavorite;
				sp.IFeature = sanPham.IFeature;
				sp.IHot = sanPham.IHot;
				sp.ISale = sanPham.ISale;
				// Cập nhật danh sách ảnh
				if (!string.IsNullOrEmpty(Imgs))
				{
                    var OldImg=db.DbImgs.Where(x=>x.MaSp == sp.MaSp).ToList();
                    if (OldImg != null)
                    {
                        db.DbImgs.RemoveRange(OldImg);
                    }
                    string[] imagePaths = Imgs.Split(';');
					foreach (var imagePath in imagePaths)
					{
						sp.DbImgs.Add(new DbImg
						{
							MaSp = sp.MaSp,
							Img = imagePath
						});
					}
				}
				// Xóa các size và màu cũ trong bảng DbChiTietSanPham
				var oldDetails = db.DbChiTietSanPhams.Where(x => x.MaSp == sanPham.MaSp);
				db.DbChiTietSanPhams.RemoveRange(oldDetails);

				// Cập nhật chi tiết sản phẩm
				if (sanPham.SelectedSizes != null && sanPham.SelectedColors != null)
				{
					foreach (var size in sanPham.SelectedSizes)
					{
						foreach (var color in sanPham.SelectedColors)
						{
							sp.DbChiTietSanPhams.Add(new DbChiTietSanPham
							{
								MaSp = sp.MaSp,
								ColorId = color,
								SizeId = size,
							});
						}
					}
				}

				await db.SaveChangesAsync();
				return RedirectToAction("SanPham");
			}
            ViewBag.MaDm = new SelectList(db.DbDanhMucs.ToList(), "MaDm", "TenDm", sanPham.MaDm);
			ViewBag.NhomId = new SelectList(db.DbGroups.ToList(), "NhomId", "GroupName", sanPham.NhomId);
			return View(sanPham);
		}
		// Xóa Sản Phẩm
		[Route("xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham(int masp)
        {
            TempData["Message"] = "";
            var img = db.DbImgs.Where(x => x.MaSp == masp).ToList() ;
            var sanpham=db.DbSanPhams.Find(masp);
            var chitietsanpham = db.DbChiTietSanPhams.Where(x => x.MaSp == masp).ToList();
            if (sanpham!=null )
            {
                if (img.Any())
                {
                    db.DbImgs.RemoveRange(img);
                }
                if(chitietsanpham.Any())
                {
                    db.DbChiTietSanPhams.RemoveRange(chitietsanpham);
                }
                db.DbSanPhams.Remove(sanpham);
                db.SaveChanges();
            }
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