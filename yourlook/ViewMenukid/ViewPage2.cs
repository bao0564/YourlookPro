using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;
namespace yourlook.ViewMenukid
{
	public class ViewPage2 : ViewComponent
	{
		private readonly IPage2 _spPage2;
		public ViewPage2(IPage2 cLSanPhamPage2)
		{
			_spPage2 = cLSanPhamPage2;
		}
		public IViewComponentResult Invoke()
		{
			var db5SanPhamPage2 = _spPage2.GetAllSanPhamPage2().Where(x => x.MaDm == 5).OrderBy(X => X.TenSp).Take(5);
			return View(db5SanPhamPage2);
		}
	}
}
