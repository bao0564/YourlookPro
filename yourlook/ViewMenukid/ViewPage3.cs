using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;
namespace yourlook.ViewMenukid
{
	public class ViewPage3 : ViewComponent
	{
		private readonly IPage3 _spPage3;
		private readonly YourlookContext _context;
		public ViewPage3(IPage3 cLSanPhamPage3, YourlookContext context)
		{
			_spPage3 = cLSanPhamPage3;
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd = new List<int>();
			if (idkh != null) 
			{
				idFvrPrd=_context.DbFavoriteProducts.AsNoTracking().Where(x=>x.MaKh==idkh.Value).Select(x=>x.MaSp).ToList();
			}
			var db5SanPhamPage3 = _spPage3.GetAllSanPhamPage3().Where(x => x.MaDm == 3).OrderBy(X => X.TenSp).Take(5);
			foreach (var prd in db5SanPhamPage3)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
			}
			return View(db5SanPhamPage3);
		}
	}
}
