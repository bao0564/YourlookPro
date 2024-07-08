using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        YourlookContext db = new YourlookContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("donhang")]
        public IActionResult DonHang()
        {
            return View();
        }
        [Route("taodonhang")]
        public IActionResult TaoDonHang()
        {
            return View();
        }
        //Color
        [Route("color")]
        public IActionResult Color(int? page)
        {
            return View();
        }
    }
}
