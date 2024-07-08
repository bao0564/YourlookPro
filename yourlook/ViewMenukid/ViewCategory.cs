using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewCategory : ViewComponent
	{
		private readonly ICategory _dm;
		public ViewCategory(ICategory category)
		{
			_dm = category;
		}
		public IViewComponentResult Invoke()
		{
			var dbdanhmuc = _dm.GetAllDanhMuc().OrderBy(X => X.TenDm);
			return View(dbdanhmuc);
		}
	}
}
