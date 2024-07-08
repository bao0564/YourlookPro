using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;
namespace yourlook.ViewMenukid
{
	public class ViewPage3 : ViewComponent
	{
		private readonly IPage3 _spPage3;
		public ViewPage3(IPage3 cLSanPhamPage3)
		{
			_spPage3 = cLSanPhamPage3;
		}
		public IViewComponentResult Invoke()
		{
			var db5SanPhamPage3 = _spPage3.GetAllSanPhamPage3().Where(x => x.MaDm == 3).OrderBy(X => X.TenSp).Take(5);
			return View(db5SanPhamPage3);
		}
	}
}
