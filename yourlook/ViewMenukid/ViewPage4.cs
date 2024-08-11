using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewPage4:ViewComponent
	{
		private readonly IPage4 _spPage4;
		private readonly YourlookContext _context;
		public ViewPage4(IPage4 cLSanPhamPage4,YourlookContext context)
		{
			_spPage4 = cLSanPhamPage4;
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd = new List<int>();
			if (idkh!=null)
			{
				idFvrPrd=_context.DbFavoriteProducts.AsNoTracking().Where(x=>x.MaKh==idkh.Value).Select(x=>x.MaSp).ToList();
			}
			var db5SanPhamPage4 = _spPage4.GetAllSanPhamPage4().Where(x => x.MaDm == 4).OrderBy(X => X.TenSp).Take(5);
			foreach (var prd in db5SanPhamPage4)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
			}
			return View(db5SanPhamPage4);
		}
	}
}
