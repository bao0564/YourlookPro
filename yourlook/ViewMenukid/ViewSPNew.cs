using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewSPNew:ViewComponent
	{
		private readonly ISanPhamNew _spNew;
		//private readonly _2442024Context _context;
		public ViewSPNew(ISanPhamNew cLSanPhamNew)
		{
			_spNew = cLSanPhamNew;
			//_context = context;
		}
		public IViewComponentResult Invoke(int maSP)
		{
			DateTime prdNew = DateTime.Now.AddDays(-50);
			var db5SanPhamNew = _spNew.GetAllSanPhamNew().Where(x => x.CreateDate >= prdNew && x.CreateDate <= DateTime.Now)
				.OrderByDescending(X => X.CreateDate).Take(10);
			return View(db5SanPhamNew);
		}
	}
}
