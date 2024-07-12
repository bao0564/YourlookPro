using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace yourlook.Areas.Admin.Controllers
{
	[Area("admin")]
	[Route("ads")]
	public class AddController : Controller
	{
		YourlookContext db= new YourlookContext();
		[Route("ads")]
		public IActionResult Ads(int? page)
		{
			int pageSize = 10;
			int pageNumber = page ?? 1;
			var lstAds=db.DbAdds.AsNoTracking().OrderBy(x=>x.Id).ToList();
			PagedList<DbAdd> lst= new PagedList<DbAdd>(lstAds,pageNumber,pageSize);
			return View(lst);
		}
	}
}
