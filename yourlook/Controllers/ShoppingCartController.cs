﻿
//using Data.Migrations;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.PortableExecutable;
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
            var idkh = HttpContext.Session.GetInt32("userid");
            var userAdress=db.DbAddreses.Where(x=>x.MaKh==idkh).ToList();
            var pay=db.DbPayments.ToList();
            var voucher=db.DbVouchers.ToList();
            var cart = HttpContext.Session.GetJson<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var item = new ShoppingCartDetail
            {
                Address = userAdress,
                Items = cart,
                Payments =pay,
                Vouchers = voucher
            };

            return View(item);
		}
        [AllowAnonymous]
		[HttpPost]
		public IActionResult AddToCart(int masp,int quantity,int sizeid,int colorid)
		{
			var code = new { success = false, msg = "", code = -1};
			var db = new YourlookContext();
			var checkproduct = db.DbSanPhams.FirstOrDefault(x => x.MaSp == masp);
            var checkSize = db.DbSizes.FirstOrDefault(x => x.SizeId == sizeid);
            var checkColor = db.DbColors.FirstOrDefault(x => x.ColorId == colorid);
			if (checkproduct != null)
			{
				var cart = HttpContext.Session.GetJson<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
                var exitprd = cart.FirstOrDefault(x => x.ProductId == masp && x.ColorId == colorid && x.SizeId == sizeid);
                if (exitprd!=null)
                {
					// Nếu đã tồn tại, cập nhật số lượng
					exitprd.ProductQuantity += quantity;
					exitprd.Total = exitprd.ProductQuantity * exitprd.ProductPrice;
				}
                else
                {
					ShoppingCartItem item = new ShoppingCartItem
					{
						ProductId = checkproduct.MaSp,
						ProductName = checkproduct.TenSp,
						ProductImg = checkproduct.AnhSp,
						CategoryName = checkproduct.MaDanhMucsMaDm?.TenDm,
						ProductQuantity = quantity,
						ColorId = colorid,
						SizeId = sizeid,
						ColorName = checkColor.NameColor,
						SizeName = checkSize.NameSize,
						ProductPrice = checkproduct.GiamGia > 0 ? checkproduct.PriceMin : checkproduct.PriceMax,
						Total = (checkproduct.GiamGia > 0 ? checkproduct.PriceMin : checkproduct.PriceMax) * quantity
					};
					cart.Add(item);
				}
				HttpContext.Session.SetJson("Cart", cart);

				code = new { success = true, msg = "Sản phẩm đã được thêm vào giỏ hàng", code = 0};
			}
			return Json(code);
		}
        //hiển thị địa chỉ
        public IActionResult addressUser()
        {
			var idkh = HttpContext.Session.GetInt32("userid");			
			var adress = db.DbAddreses.Where(X => X.MaKh == idkh.Value).ToList();
            return PartialView("addressUser",adress);
		}
        [HttpPost]
        public IActionResult Checkout([FromBody] CheckoutRequest request)
        {
            var cart = HttpContext.Session.GetJson<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var selectedItems = new List<CheckOutItem>();

            foreach (var product in request.selectedProducts)
            {
                var item = cart.FirstOrDefault(x => x.ProductId == product.ProductId && x.ColorId == product.ColorId && x.SizeId == product.SizeId);
                if (item != null)
                {
                    var checkoutItem = new CheckOutItem
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductImg = item.ProductImg,
                        CategoryName = item.CategoryName,
                        ProductQuantity = product.ProductQuantity,
                        ColorId = item.ColorId,
                        SizeId = item.SizeId,
                        ColorName = item.ColorName,
                        SizeName = item.SizeName,
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
                PayName =orderInfor.payname,
                Icon = orderInfor.icon,
                GiamGia=orderInfor.GiamGia,
                Ship=orderInfor.Ship,
                CheckOutItems = selectedItems
            };
            return View(item);
        }
        [HttpPost]
        public IActionResult PayOrder()
        {
            try
            {
                var selectedItems = HttpContext.Session.GetJson<List<CheckOutItem>>("Order");
                var orderInfor = HttpContext.Session.GetJson<OrderInforItem>("OrderInfo");
                //tính tiền đã trừ đi mã giảm giá
                var tongtien=selectedItems.Sum(x=>x.Total);
                decimal Giamgia = orderInfor.GiamGia ?? 0;
                decimal giamGiaValue = (tongtien * Giamgia / 100);
                var ship=orderInfor.Ship;
                var finaltotal = tongtien - giamGiaValue + ship;
                var tongsoluong=selectedItems.Sum(x=>x.ProductQuantity);
                var emailkh = HttpContext.Session.GetString("user");
                var idkh = HttpContext.Session.GetInt32("userid");
                var order = new DbDonHang
                {
                    MaKh = idkh.Value,
                    EmailKh = emailkh,
                    TenKh = orderInfor.TenKh,
                    Sdt = orderInfor.Sdt,
                    City = orderInfor.City,
                    District = orderInfor.District,
                    Ward = orderInfor.Ward,
                    DiaChi = orderInfor.DiaChi,
                    PaymentId = orderInfor.PaymentId,
                    PaymentName=orderInfor.payname,
                    GhiChu = orderInfor.GhiChu,
                    TongTienThanhToan= finaltotal, 
                    TongTien = tongtien,              
                    soluong = tongsoluong,
                    Giamgia = giamGiaValue,
                    Ship = orderInfor.Ship,
                    CreateDate = DateTime.Now
                };
                
                db.DbDonHangs.Add(order);
                db.SaveChanges();
                foreach (var item in selectedItems)
                {
                    var productOrder = new DbChiTietDonHang
					{
						MaKh = idkh.Value,
						EmailKh = emailkh,
						MaDh = order.MaDh,
                        MaSp = item.ProductId,
                        TenSp = item.ProductName,
                        AnhSp = item.ProductImg,
                        ColorId= item.ColorId,
                        ColorName=item.ColorName,
                        SizeId=item.SizeId,
                        SizeName=item.SizeName,
                        SoLuongSp = item.ProductQuantity,
                        Price = item.ProductPrice,
                        CreateDate = DateTime.Now
                    };
                    db.DbChiTietDonHangs.Add(productOrder);
                };
                db.SaveChanges();
                HttpContext.Session.Remove("Order");
                HttpContext.Session.Remove("OrderInfor");
                //xóa sp đã thanh toán ra khỏi giỏ hàng
                var cart = HttpContext.Session.GetJson<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
                foreach (var prd in selectedItems)
                {
                    var prdmove= cart.FirstOrDefault(x=>x.ProductId == prd.ProductId);
                    if (prdmove != null)
                    {
                        cart.Remove(prdmove);
                    };
                };
                HttpContext.Session.SetJson("Cart",cart);
                // Trả về view thành công
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log lỗi chi tiết vào console hoặc log file
                var errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += " Inner Exception: " + ex.InnerException.Message;
                }
                return Json(new { success = false, message = "Có lỗi xảy ra: " + errorMessage });
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
