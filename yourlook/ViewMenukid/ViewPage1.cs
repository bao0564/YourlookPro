using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewPage1:ViewComponent
	{
		private readonly IPage1 _spPage1;
		private readonly YourlookContext _context;
		public ViewPage1(IPage1 cLSanPhamPage1,YourlookContext context)
		{
			_spPage1 = cLSanPhamPage1;
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd=new List<int>();
			if (idkh!=null)
			{
				idFvrPrd=_context.DbFavoriteProducts.AsNoTracking().Where(x=>x.MaKh==idkh.Value).Select(x=>x.MaSp).ToList();
			}
			var db5SanPhamPage1 = _spPage1.GetAllSanPhamPage1().Where(x => x.MaDm == 1).OrderBy(X => X.TenSp).Take(5);
			foreach (var prd in db5SanPhamPage1)
			{
				prd.IFavorite=idFvrPrd.Contains(prd.MaSp);
			}
			return View(db5SanPhamPage1);
		}
	}
}
