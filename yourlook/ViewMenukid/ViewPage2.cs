using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;
namespace yourlook.ViewMenukid
{
	public class ViewPage2 : ViewComponent
	{
		private readonly IPage2 _spPage2;
		private readonly YourlookContext _context;
		public ViewPage2(IPage2 cLSanPhamPage2,YourlookContext context)
		{
			_spPage2 = cLSanPhamPage2;
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd = new List<int>();
			if (idkh!=null)
			{
				idFvrPrd=_context.DbFavoriteProducts.AsNoTracking().Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
			}
			var db5SanPhamPage2 = _spPage2.GetAllSanPhamPage2().Where(x => x.MaDm == 5).OrderBy(X => X.TenSp).Take(5);
			foreach (var prd in db5SanPhamPage2)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
			}
			return View(db5SanPhamPage2);
		}
	}
}
