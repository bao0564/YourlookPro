using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace yourlook.Areas.Admin.Controllers
{
    
    public class RoleController : Controller
    {
        YourlookContext db=new YourlookContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
