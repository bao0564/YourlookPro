using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;
using yourlook.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace yourlook.Controllers
{
    public class HomeController : Controller
    {
        YourlookContext db=new YourlookContext();
		//trang chủ 
        public IActionResult Index()
        {
			var email = HttpContext.Session.GetString("user");
			if(email != null)
			{
				var user= GetEmailKhachHang(email);
			}
            return View();
		}
			private DbKhachHang GetEmailKhachHang(string email)
			{
				using (var db = new YourlookContext())
				{
					return db.DbKhachHangs.FirstOrDefault(x => x.Email==email);
				}
			}
			private DbKhachHang GetIdKhachHang(int id)
			{
				using (var db = new YourlookContext())
				{
					return db.DbKhachHangs.FirstOrDefault(x => x.MaKh == id);
				}
			}
		//thông tin tài khoản 
		public IActionResult UserDetail()
        {
            var email = HttpContext.Session.GetString("user");
            if (email != null)
            {
                var user = GetEmailKhachHang(email);
				return View(user);
            }
			else
			{
				return RedirectToAction("Login", "Access");
			}
        }
		//tìm từ khóa
		public IActionResult KeyWord(int? page, string keyword)
		{
            int pageSize = 25;
            int pageNumber = page ?? 1;
			var item = from sp in db.DbSanPhams
					   join dm in db.DbDanhMucs on sp.MaDm equals dm.MaDm
					   where (string.IsNullOrEmpty(keyword) || sp.TenSp.Contains(keyword) || dm.TenDm.Contains(keyword))
					   select new DbSanPham
					   {
						   MaSp = sp.MaSp,
						   TenSp = sp.TenSp,
						   GiamGia= sp.GiamGia,
						   AnhSp = sp.AnhSp,
						   PriceMax = sp.PriceMax,
						   PriceMin = sp.PriceMin,
					   };
            var lst = item.ToList();
            PagedList<DbSanPham> lstsp = new PagedList<DbSanPham>(lst, pageNumber, pageSize);
            return View(lstsp);
		}
		//sản phẩm yêu thích
		[HttpGet]		
		public IActionResult FavoriteProduct()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			if (idkh ==null)
			{
				return RedirectToAction("Login", "Access");
			}
			var favoriteProducts = db.GetFavoriteProducts(idkh.Value);
			return View(favoriteProducts);
		}

        [HttpPost]		
		public IActionResult FavoriteProduct(int masp)
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			if (idkh==null)
			{
				return Json(new { success = false, message = "Hãy đăng nhập để sử dụng thao tác này" });
			}
			var user = GetIdKhachHang(idkh.Value);
			var isFvr = db.DbFavoriteProducts.FirstOrDefault(x => x.MaKh == user.MaKh && x.MaSp == masp);
			if (isFvr == null) 
			{
				isFvr = new DbFavoriteProduct
				{
					MaSp = masp,
					MaKh = user.MaKh,
					CreatDate = DateTime.Now
				};
				db.DbFavoriteProducts.Add(isFvr);
				db.SaveChanges();
				return Json(new { success = true, message = "Đã thêm vào mục yêu thích" });
			}
			else
			{
				db.DbFavoriteProducts.Remove(isFvr);
				db.SaveChanges();
				return Json(new { success = true, message = "Đã xóa khỏi mục yêu thích" });
			}
		}
		public IActionResult AllProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd=new List<int>();
			if (idkh !=null)
			{
                idFvrPrd = db.DbFavoriteProducts.Where(x=>x.MaKh==idkh.Value).Select(x=>x.MaSp).ToList();
			}
			var lstAllSanPham = db.DbSanPhams.AsNoTracking().Where(x=>x.IActive==true).OrderBy(x => x.TenSp).ToList();
            var newlst = new List<ViewAllDetail>();
            foreach (var prd in lstAllSanPham)
            {
                var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
                var lstColor = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Color).Distinct().ToList();
                newlst.Add(new ViewAllDetail
                {
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }
            PagedList<ViewAllDetail> lstsp = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
			return View(lstsp);
		}
        public IActionResult SellProduct(int? page)
        {
			int pageSize = 25;
			int pageNumber = page ?? 1; 
			var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstSellSanPham = db.DbSanPhams.AsNoTracking().Where(x => x.ISale == true).OrderBy(x => x.TenSp).ToList();
            var newlst = new List<ViewAllDetail>();
            foreach (var prd in lstSellSanPham)
            {
                var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
                var lstColor = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Color).Distinct().ToList();
                newlst.Add(new ViewAllDetail
                {
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }
            PagedList<ViewAllDetail> lstsp = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
			return View(lstsp);
        }
		public IActionResult NewProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			DateTime prdNew = DateTime.Now.AddDays(-30);
            var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstNewProduct = db.DbSanPhams.AsNoTracking()
                .Where(x => x.CreateDate >= prdNew && x.CreateDate <= DateTime.Now)
                .OrderByDescending(x => x.CreateDate).ToList();
            var newlst = new List<ViewAllDetail>();
            foreach (var prd in lstNewProduct)
            {
                var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
                var lstColor = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Color).Distinct().ToList();
                newlst.Add(new ViewAllDetail
                {
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }
            PagedList<ViewAllDetail> lstNew = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
			return View(lstNew);
		}
		public IActionResult HotProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
            var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstHotProduct = db.DbSanPhams.AsNoTracking().Where(x => x.IHot == true).OrderByDescending(x => x.LuotSold).ToList();
            var newlst = new List<ViewAllDetail>();
            foreach (var prd in lstHotProduct)
            {
                var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
                var lstColor = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Color).Distinct().ToList();
                newlst.Add(new ViewAllDetail
                {
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }
            PagedList<ViewAllDetail> lstHot = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
			return View(lstHot);
		}
		public IActionResult UnderProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
            var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstUnderProduct = db.DbSanPhams.AsNoTracking().Where(x => x.MaDm == 2).OrderByDescending(x => x.MaSp).ToList();
            var newlst = new List<ViewAllDetail>();
            foreach (var prd in lstUnderProduct)
            {
                var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
                var lstColor = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Color).Distinct().ToList();
                newlst.Add(new ViewAllDetail
                {
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }
            PagedList<ViewAllDetail> lstNew = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
			return View(lstNew);
		}
		public IActionResult ProductCategory(int? page)
		{
            int pageSize = 15;
            int pageNumber = page ?? 1;
            var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstcateSanPham = db.DbSanPhams.AsNoTracking().Where(x => x.IActive == true).OrderBy(x => x.TenSp).ToList();
			var newlst=new List<ViewAllDetail>();
            foreach (var prd in lstcateSanPham)
            {
				var lstSize = db.DbChiTietSanPhams.Where(x => x.MaSp == prd.MaSp).Select(x => x.Size).Distinct().ToList();
				var lstColor=db.DbChiTietSanPhams.Where(x=>x.MaSp==prd.MaSp).Select(x=>x.Color).Distinct().ToList();
				newlst.Add(new ViewAllDetail
				{
                    MaSp = prd.MaSp,
                    TenSp = prd.TenSp,
                    AnhSp = prd.AnhSp,
                    PriceMax = prd.PriceMax,
                    PriceMin = prd.PriceMin,
                    GiamGia = prd.GiamGia,
                    IFavorite = idFvrPrd.Contains(prd.MaSp),
                    Sizes = lstSize,
                    Colors = lstColor,
                    LuotXem = prd.LuotXem
                });
            }            
            PagedList<ViewAllDetail> lstcatesp = new PagedList<ViewAllDetail>(newlst, pageNumber, pageSize);
            return View(lstcatesp);
        }
		public IActionResult ProductTipe(int madm,int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
            var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null)
            {
                idFvrPrd = db.DbFavoriteProducts.Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
            }
            var lstProductTipe = db.DbSanPhams.AsNoTracking().Where(x => x.MaDm == madm).OrderBy(x => x.TenSp).ToList();
			var newLst = new List<ViewAllDetail>();           
            foreach (var prd in lstProductTipe)
            {
                var lstSize = db.DbChiTietSanPhams
								.Where(x =>x.MaSp==prd.MaSp)
                                .Select(x => x.Size)
                                .Distinct()
                                .ToList();
                var lstColor= db.DbChiTietSanPhams
								.Where(x => x.MaSp == prd.MaSp)
                                .Select(x => x.Color)
                                .Distinct()
                                .ToList();
				newLst.Add(new ViewAllDetail
                {
					MaSp = prd.MaSp,
					TenSp = prd.TenSp,
					AnhSp = prd.AnhSp,
					PriceMax = prd.PriceMax,
					PriceMin = prd.PriceMin,
					GiamGia = prd.GiamGia,
					IFavorite = idFvrPrd.Contains(prd.MaSp),
					Sizes=lstSize,
					Colors=lstColor,
					LuotXem=prd.LuotXem
				});            
			}            
			PagedList<ViewAllDetail> lstprdbytipe = new PagedList<ViewAllDetail>(newLst, pageNumber,pageSize);
			return View(lstprdbytipe);
		}
		public IActionResult ProductDetail(int masp)
		{
			var lstSanPham = db.DbSanPhams.SingleOrDefault(x => x.MaSp == masp);
			if(lstSanPham != null) {
				db.DbSanPhams.Attach(lstSanPham);
				lstSanPham.LuotXem = lstSanPham.LuotXem + 1;
				db.Entry(lstSanPham).Property(X=>X.LuotXem).IsModified = true;
				db.SaveChanges();
			};
			var lstImgProduct = db.DbImgs.Where(x => x.MaSp == masp).ToList();
			//.Distinct() để loại bỏ các size, color trùng lặp
			var lstSizeProduct = db.DbChiTietSanPhams.Where(x => x.MaSp == masp)
										.Where(x => x.MaSp == masp)
										.Select(x => x.Size)
										.Distinct()
										.ToList();
			var lstColorProduct = db.DbChiTietSanPhams.Where(x => x.MaSp == masp)
										.Where(x => x.MaSp == masp)
										.Select(x => x.Color)
										.Distinct()
										.ToList();
			var idkh=HttpContext.Session.GetInt32("userid");
			bool isFavorite = false;
			if (idkh != null)
			{
				isFavorite = db.DbFavoriteProducts.Any(x => x.MaKh == idkh.Value && x.MaSp == masp);
			}
			var viewmodel = new ProductDetailViewModel
			{
				SanPham = lstSanPham,
				SizeProduct=lstSizeProduct,
				ColorProduct=lstColorProduct,
				IsFavorite = isFavorite,
				ImgProduct = lstImgProduct
			};

			return View(viewmodel);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
