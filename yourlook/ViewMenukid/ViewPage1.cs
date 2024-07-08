using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewPage1:ViewComponent
	{
		private readonly IPage1 _spPage1;
		public ViewPage1(IPage1 cLSanPhamPage1)
		{
			_spPage1 = cLSanPhamPage1;
		}
		public IViewComponentResult Invoke()
		{
			var db5SanPhamPage1 = _spPage1.GetAllSanPhamPage1().Where(x => x.MaDm == 1).OrderBy(X => X.TenSp).Take(5);
			return View(db5SanPhamPage1);
		}
	}
}
