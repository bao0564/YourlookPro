using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace yourlook.Controllers
{
    public class AboutController : Controller
    {
        private YourlookContext db=new YourlookContext();
        public IActionResult About()
        {
            return View();
        }
    }
}
