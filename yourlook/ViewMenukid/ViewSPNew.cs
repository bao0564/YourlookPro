using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewSPNew:ViewComponent
	{
		private readonly ISanPhamNew _spNew;
		private readonly YourlookContext _context;

		public ViewSPNew(ISanPhamNew cLSanPhamNew,YourlookContext context)
		{
			_spNew = cLSanPhamNew;
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
			DateTime prdNew = DateTime.Now.AddDays(-50);
			var db5SanPhamNew = _spNew.GetAllSanPhamNew().Where(x => x.CreateDate >= prdNew && x.CreateDate <= DateTime.Now)
				.OrderByDescending(X => X.CreateDate).Take(10);
			foreach( var prd in db5SanPhamNew)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
			}
			return View(db5SanPhamNew);
		}
	}
}
