using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;
using yourlook.Models;

namespace yourlook.Controllers
{     
    public class UserController : Controller
    {
        YourlookContext db=new YourlookContext();
        private readonly IUploadPhoto _uploadPhoto;
        public UserController( IUploadPhoto uploadPhoto)
        {
            _uploadPhoto = uploadPhoto;
        }

        //thông tin tài khoản 
        public IActionResult UserDetail()
        {
            var email = HttpContext.Session.GetString("user");
            if (email != null)
            {
                var user = GetEmailKhachHang(email);
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Access");
            }
        }
        //sửa thông tin tài khoản
        [HttpGet]
        public IActionResult UpdateUserDetail(int makh)
        {
            var KhachHang=db.DbKhachHangs.Find(makh);
            return View(KhachHang);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateUserDetail(DbKhachHang khachhang,IFormFile FileAnh)
		{
            if (ModelState.IsValid)
            {
                if (FileAnh !=null && FileAnh.Length>0)
                {
                    khachhang.Img = await _uploadPhoto.uploadOnePhotosAsync(FileAnh, "img");
                }
                db.DbKhachHangs.Attach(khachhang);
                khachhang.ModifiedDate= DateTime.Now;
                db.Entry(khachhang).State= EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("UserDetail", "User");
            }
			return View(khachhang);
		}
		private DbKhachHang GetEmailKhachHang(string email)
        {
            using (var db = new YourlookContext())
            {
                return db.DbKhachHangs.FirstOrDefault(x => x.Email == email);
            }
        }
        private DbKhachHang GetIdKhachHang(int id)
        {
            using (var db = new YourlookContext())
            {
                return db.DbKhachHangs.FirstOrDefault(x => x.MaKh == id);
            }
        }
        //sản phẩm yêu thích
        [HttpGet]
        public IActionResult FavoriteProduct()
        {
            var idkh = HttpContext.Session.GetInt32("userid");
            if (idkh == null)
            {
                return RedirectToAction("Login", "Access");
            }
            var favoriteProducts = db.GetFavoriteProducts(idkh.Value);
            return View(favoriteProducts);
        }

        [HttpPost]
        public IActionResult FavoriteProduct(int masp)
        {
            var idkh = HttpContext.Session.GetInt32("userid");
            if (idkh == null)
            {
                return Json(new { success = false, message = "Hãy đăng nhập để sử dụng thao tác này" });
            }
            var user = GetIdKhachHang(idkh.Value);
            var isFvr = db.DbFavoriteProducts.FirstOrDefault(x => x.MaKh == user.MaKh && x.MaSp == masp);
            if (isFvr == null)
            {
                isFvr = new DbFavoriteProduct
                {
                    MaSp = masp,
                    MaKh = user.MaKh,
                    CreatDate = DateTime.Now
                };
                db.DbFavoriteProducts.Add(isFvr);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã thêm vào mục yêu thích" });
            }
            else
            {
                db.DbFavoriteProducts.Remove(isFvr);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã xóa khỏi mục yêu thích" });
            }
        }

        //lịch sử mua hàng
        public IActionResult HistoryOrder()
        {
            var idkh = HttpContext.Session.GetInt32("userid");
            //var emailkh = HttpContext.Session.GetString("user");
            if (idkh == null)
            {
                return RedirectToAction("Login", "Access");
            }
            var historyOrder = db.DbDonHangs.Where(ho => ho.MaKh == idkh)
                            .Include(ho => ho.DbChiTietDonHangs)
                            .Select(ho => new ViewHistoryOrder
                            {
                                MaDh = ho.MaDh,
                                TongTien = ho.TongTien,
                                TongTienThanhToan = ho.TongTienThanhToan,
                                PaymentName = ho.PaymentName,
                                MaVoucher = ho.MaVoucher,
                                Giamgia = ho.Giamgia,
                                Ship = ho.Ship,
                                GhiChu = ho.GhiChu,
                                ODSuccess = ho.ODSuccess,
                                ODReadly = ho.ODReadly,
                                ODTransported = ho.ODTransported,
                                Complete = ho.Complete,
                                CreateDate = ho.CreateDate,
                                DhDetail = ho.DbChiTietDonHangs.ToList()
                            }).OrderByDescending(ho => ho.CreateDate).ToList();

            return View(historyOrder);
        }
    }
}
