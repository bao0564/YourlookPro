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
				ViewBag.TenKH=user.TenKh;
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
        public IActionResult KeyWord(int? page,string word)
		{
            int pageSize = 25;
            int pageNumber = page ?? 1;
            var lst = db.DbSanPhams.AsNoTracking().Where(x => x.TenSp.Contains(word)).OrderBy(x => x.CreateDate).ToList();
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
			foreach (var prd in lstAllSanPham)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }
			PagedList<DbSanPham> lstsp = new PagedList<DbSanPham>(lstAllSanPham, pageNumber, pageSize);
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
            foreach (var prd in lstSellSanPham)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }            
			PagedList<DbSanPham> lstsp = new PagedList<DbSanPham>(lstSellSanPham, pageNumber, pageSize);
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
            foreach (var prd in lstNewProduct)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }
			PagedList<DbSanPham> lstNew = new PagedList<DbSanPham>(lstNewProduct, pageNumber, pageSize);
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
            foreach (var prd in lstHotProduct)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }            
			PagedList<DbSanPham> lstHot = new PagedList<DbSanPham>(lstHotProduct, pageNumber, pageSize);
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
            foreach (var prd in lstUnderProduct)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }
			PagedList<DbSanPham> lstNew = new PagedList<DbSanPham>(lstUnderProduct, pageNumber, pageSize);
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
            foreach (var prd in lstcateSanPham)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }            
            PagedList<DbSanPham> lstcatesp = new PagedList<DbSanPham>(lstcateSanPham, pageNumber, pageSize);
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
            List<DbSanPham> lstProductTipe = db.DbSanPhams.AsNoTracking().Where(x => x.MaDm == madm).OrderBy(x => x.TenSp).ToList(); ;
            foreach (var prd in lstProductTipe)
            {
                prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
            }            
			ViewBag.Madm = madm;
			PagedList<DbSanPham> lstprdbytipe = new PagedList<DbSanPham>(lstProductTipe, pageNumber,pageSize);
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
			ViewBag.ImgProduct = lstImgProduct;
			var idkh=HttpContext.Session.GetInt32("userid");
			bool isFavorite = false;
			if (idkh != null)
			{
				isFavorite = db.DbFavoriteProducts.Any(x => x.MaKh == idkh.Value && x.MaSp == masp);
			}
			ViewBag.FvrPrd = isFavorite;

			return View(lstSanPham);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
