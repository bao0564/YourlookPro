using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewPage4:ViewComponent
	{
		private readonly IPage4 _spPage4;
		public ViewPage4(IPage4 cLSanPhamPage4)
		{
			_spPage4 = cLSanPhamPage4;
		}
		public IViewComponentResult Invoke()
		{
			var db5SanPhamPage4 = _spPage4.GetAllSanPhamPage4().Where(x => x.MaDm == 4).OrderBy(X => X.TenSp).Take(5);
			return View(db5SanPhamPage4);
		}
	}
}
