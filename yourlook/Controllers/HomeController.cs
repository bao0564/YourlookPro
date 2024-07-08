using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;
using yourlook.Models;

namespace yourlook.Controllers
{
    public class HomeController : Controller
    {
        YourlookContext db=new YourlookContext();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
		}
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult AllProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			var lstAllSanPham = db.DbSanPhams.AsNoTracking().Where(x=>x.IActive==true).OrderBy(x => x.TenSp);
			PagedList<DbSanPham> lstsp = new PagedList<DbSanPham>(lstAllSanPham, pageNumber, pageSize);
			return View(lstsp);
		}
        public IActionResult SellProduct(int? page)
        {
			int pageSize = 25;
			int pageNumber = page ?? 1;
			var lstSellSanPham = db.DbSanPhams.AsNoTracking().Where(x => x.ISale == true).OrderBy(x => x.TenSp);
			PagedList<DbSanPham> lstsp = new PagedList<DbSanPham>(lstSellSanPham, pageNumber, pageSize);
			return View(lstsp);
        }
		public IActionResult NewProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			DateTime prdNew = DateTime.Now.AddDays(-30);
			var lstNewProduct = db.DbSanPhams.AsNoTracking()
				.Where(x => x.CreateDate >= prdNew && x.CreateDate <= DateTime.Now)
				.OrderByDescending(x => x.CreateDate);
			PagedList<DbSanPham> lstNew = new PagedList<DbSanPham>(lstNewProduct, pageNumber, pageSize);
			return View(lstNew);
		}
		public IActionResult HotProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			var lstHotProduct = db.DbSanPhams.AsNoTracking().Where(x=>x.IHot==true).OrderByDescending(x => x.LuotSold);
			PagedList<DbSanPham> lstHot = new PagedList<DbSanPham>(lstHotProduct, pageNumber, pageSize);
			return View(lstHot);
		}
		public IActionResult UnderProduct(int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;			
			var lstUnderProduct = db.DbSanPhams.AsNoTracking().Where(x=>x.MaDm==2).OrderByDescending(x => x.MaSp);
			PagedList<DbSanPham> lstNew = new PagedList<DbSanPham>(lstUnderProduct, pageNumber, pageSize);
			return View(lstNew);
		}
		public IActionResult ProductCategory(int? page)
		{
            int pageSize = 15;
            int pageNumber = page ?? 1;
            var lstcateSanPham = db.DbSanPhams.AsNoTracking().Where(x => x.IActive == true).OrderBy(x => x.TenSp);
            PagedList<DbSanPham> lstcatesp = new PagedList<DbSanPham>(lstcateSanPham, pageNumber, pageSize);
            return View(lstcatesp);
        }
		public IActionResult ProductTipe(int madm,int? page)
		{
			int pageSize = 25;
			int pageNumber = page ?? 1;
			List<DbSanPham> lstProductTipe= db.DbSanPhams.AsNoTracking().Where(x=>x.MaDm==madm).OrderBy(x=>x.TenSp).ToList();
			ViewBag.Madm = madm;
			PagedList<DbSanPham> lstprdbytipe = new PagedList<DbSanPham>(lstProductTipe, pageNumber,pageSize);
			return View(lstprdbytipe);
		}
		public IActionResult ProductDetail(int masp)
		{
			var lstSanPham = db.DbSanPhams.SingleOrDefault(x => x.MaSp == masp);
			var lstImgProduct = db.DbImgs.Where(x => x.MaSp == masp).ToList();
			ViewBag.ImgProduct = lstImgProduct;
			return View(lstSanPham);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
