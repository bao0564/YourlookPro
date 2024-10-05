using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using yourlook.MenuKid;

namespace yourlook.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class AdsController : Controller
    {
        YourlookContext db=new YourlookContext();
        private readonly IUploadPhoto _uploadPhoto;
        public AdsController(IUploadPhoto uploadPhoto)
        {
            _uploadPhoto = uploadPhoto;
        }

        [Route("ads")]
        public IActionResult Ads(int? page)
        {
            var name = HttpContext.Session.GetString("NameAdmin");
            if (name == null)
            {
                return RedirectToAction("Login", "HomeAdmin");
            }
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var lstAds = db.DbAdds.AsNoTracking().OrderByDescending(x => x.Id);
            PagedList<DbAdd> lst = new PagedList<DbAdd>(lstAds, pageNumber, pageSize);
            return View(lst);
        }
        //Thêm Ads

        [Route("taoads")]
        [HttpGet]
        public IActionResult TaoAds()
        {
            return View();
        }

        [Route("taoads")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaoAds(DbAdd ads, IFormFile FileAnh)
        {
            if (ModelState.IsValid)
            {
                if(FileAnh !=null && FileAnh.Length > 0)
                {
                    ads.Img = await _uploadPhoto.uploadOnePhotosAsync(FileAnh, "logo");
                }
                ads.CreateDate = DateTime.Now;
                db.DbAdds.Add(ads);
                await db.SaveChangesAsync();
                return RedirectToAction("Ads");
            }
            return View(ads);
        }

        //Xóa Danh Mục
        [Route("xoaads")]
        [HttpGet]
        public IActionResult XoaAds(int id)
        {
            TempData["Message"] = "";            
            var ads = db.DbAdds.Find(id);
            if (ads != null)
            {
                db.DbAdds.Remove(ads);
                db.SaveChanges();
            }
            TempData["Message"] = "ĐÃ XÓA";
            return RedirectToAction("ads");
        }
        //[HttpPost]
        //public async Task<IActionResult> UploadImg(List<IFormFile> files)
        //{
        //    var filePaths = new List<string>();
        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "logo");
        //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //            string filePath = Path.Combine(uploadDir, fileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            }

        //            filePaths.Add("/logo/" + fileName);
        //        }
        //    }

        //    return Json(new { success = true, filePaths });
        //}
    }
}