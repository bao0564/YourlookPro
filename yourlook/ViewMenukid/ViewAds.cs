using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
	public class ViewAds: ViewComponent
	{
		private readonly IAds ads;
		public ViewAds(IAds Ads)
		{
			ads = Ads;
		}
		public IViewComponentResult Invoke()
		{
			var dbads = ads.GetAllAds().OrderBy(X => X.IsActive==true);
			return View(dbads);
		}
	}
}
