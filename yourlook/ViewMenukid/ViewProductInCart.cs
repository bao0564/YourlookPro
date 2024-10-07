using Microsoft.AspNetCore.Mvc;
using yourlook.Extension;
using yourlook.Models;

namespace yourlook.ViewMenukid
{
	public class ViewProductInCart:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var prdCart = HttpContext.Session.GetJson<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
			int itemCount = prdCart.Sum(i => i.ProductQuantity);

			return View(itemCount); // Trả về view kèm theo số lượng sản phẩm
		}
	}
}
