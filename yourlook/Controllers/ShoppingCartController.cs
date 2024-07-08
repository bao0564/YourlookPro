
using Data.Migrations;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks.Dataflow;
using yourlook.Extension;
using yourlook.Models;

namespace yourlook.Controllers
{
    public class ShoppingCartController : Controller
	{
		YourlookContext db = new YourlookContext();
		public IActionResult Index()
		{
            var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();
            if (cart != null)
            {
                return View(cart.Items);
            }
            return View();
		}
        //partial để tachs sản phẩm trong giỏ hàng và thông tin khách hàng và địa chỉ trong Index
        //public IActionResult Partial_Product_In_Cart()
        //{
        //    var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();            
        //    return PartialView(cart.Items);
        //}
        //public IActionResult Partial_Infor_In_Cart()
        //{
        //    return PartialView();
        //}
        [AllowAnonymous]
		[HttpPost]
		public IActionResult AddToCart(int masp,int quantity)
		{
			var code = new { success = false, msg = "", code = -1};
			var db = new YourlookContext();
			var checkproduct = db.DbSanPhams.FirstOrDefault(x => x.MaSp == masp);
			if (checkproduct != null)
			{
				var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();
				ShoppingCartItem item = new ShoppingCartItem
				{
					ProductId = checkproduct.MaSp,
					ProductName = checkproduct.TenSp,
					ProductImg = checkproduct.AnhSp,
					CategoryName = checkproduct.MaDanhMucsMaDm?.TenDm,
					ProductQuantity = quantity,
					ProductPrice = checkproduct.GiamGia > 0 ? checkproduct.PriceMin : checkproduct.PriceMax,
					Total = (checkproduct.GiamGia > 0 ? checkproduct.PriceMin : checkproduct.PriceMax) * quantity
				};
				cart.AddToCart(item, quantity);
				HttpContext.Session.SetJson("Cart", cart);

				code = new { success = true, msg = "Thêm sản phẩm thành công", code = 0};
			}
			return Json(code);
		}

        [HttpPost]
        public IActionResult Checkout([FromBody] CheckoutRequest request)
        {
            var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();
            var selectedItems = new List<CheckOutItem>();

            foreach (var product in request.selectedProducts)
            {
                var item = cart.Items.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (item != null)
                {
                    var checkoutItem = new CheckOutItem
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductImg = item.ProductImg,
                        CategoryName = item.CategoryName,
                        ProductQuantity = product.ProductQuantity,
                        ProductPrice = item.ProductPrice,
                        Total = item.ProductPrice * product.ProductQuantity
                    };
                    selectedItems.Add(checkoutItem);
                }
            }

            HttpContext.Session.SetJson("Order", selectedItems);
            HttpContext.Session.SetJson("OrderInfo", request.selectInfors);

            return Json(new { success = true });
        }

        public IActionResult Order()
        {
            var selectedItems = HttpContext.Session.GetJson<List<CheckOutItem>>("Order") ?? new List<CheckOutItem>();
            var orderInfor = HttpContext.Session.GetJson<OrderInforItem>("OrderInfo") ?? new OrderInforItem();
            var item = new ViewCheckOutItem
            {
                TenKh = orderInfor.TenKh,
                Sdt = orderInfor.Sdt,
                City = orderInfor.City,
                District = orderInfor.District,
                Ward = orderInfor.Ward,
                DiaChi = orderInfor.DiaChi,
                TongTien=orderInfor.TongTien,
                PaymentId = orderInfor.PaymentId,
                GhiChu = orderInfor.GhiChu,
                CheckOutItems = selectedItems
            };
            return View(item);
        }
        //public IActionResult Order_Infor_In_Cart()
        //{
        //    return PartialView();
        //}
        [HttpPost]
        public IActionResult PayOrder()
        {
            try
            {
                var selectedItems = HttpContext.Session.GetJson<List<CheckOutItem>>("Order");
                var orderInfor = HttpContext.Session.GetJson<OrderInforItem>("OrderInfo");

                if (selectedItems == null || orderInfor == null)
                {
                    return Json(new { success = false, message = "Session data for Order or OrderInfo is null." });
                }
                var order = new DbDonHang
                {
                    TenKh = orderInfor.TenKh,
                    Sdt = orderInfor.Sdt,
                    City = orderInfor.City,
                    District = orderInfor.District,
                    Ward = orderInfor.Ward,
                    DiaChi = orderInfor.DiaChi,
                    PaymentId = orderInfor.PaymentId,
                    GhiChu = orderInfor.GhiChu
                };
                db.DbDonHangs.Add(order);
                db.SaveChanges();
                foreach (var item in selectedItems)
                {
                    var productOrder = new DbChiTietDonHang
                    {
                        MaDh = order.MaDh,
                        MaSp = item.ProductId,
                        TenSp = item.ProductName,
                        AnhSp = item.ProductImg,
                        SoLuongSp = item.ProductQuantity,
                        Price = item.ProductPrice
                    };
                    db.DbChiTietDonHangs.Add(productOrder);
                };
                db.SaveChanges();
                HttpContext.Session.Remove("Order");
                HttpContext.Session.Remove("OrderInfor");
                // Trả về view thành công
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết vào console hoặc log file
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                return Json(new { success = false, message = ex.Message });
            }
        }
        public IActionResult PayOrderSuccess()
        {
            return View();
        }
        [HttpPost]
		public ActionResult Delete(int id)
		{
            var code = new { success = false, msg = "", code = -1, Count = 0 };
            var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();
			if (cart != null)
			{ 
				var checkproduct=cart.Items.FirstOrDefault(x=>x.ProductId == id);
				if (checkproduct != null) { 
					cart.Remove(id);
                    HttpContext.Session.SetJson("Cart", cart);
                    code = new { success = true ,msg="Đã xóa sản phẩm",code=0,Count=cart.Items.Count};
				}
			}
			return Json(code);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            var cart = HttpContext.Session.GetJson<ViewShoppingCartItem>("Cart") ?? new ViewShoppingCartItem();
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                HttpContext.Session.SetJson("Cart", cart);
                return Json(new { Success = true });
            }
            return Json(new {Success=false});
        }

    }
}
