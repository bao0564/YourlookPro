using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
    public class ViewFlashSell:ViewComponent
    {
        private readonly IFlashSell _sp;
        private readonly YourlookContext _context;
        public ViewFlashSell(IFlashSell sp, YourlookContext context)
        {
            _sp = sp;
            _context = context;
        }
        public IViewComponentResult Invoke()
		{
			var idkh = HttpContext.Session.GetInt32("userid");
			var idFvrPrd = new List<int>();
			if (idkh != null)
			{
				idFvrPrd = _context.DbFavoriteProducts.AsNoTracking().Where(x => x.MaKh == idkh.Value).Select(x => x.MaSp).ToList();
			}
			var dbsanpham = _sp.GetAllSanPhamFlashSell().OrderBy(X => X.ISale==true).Take(10);
			foreach (var prd in dbsanpham)
			{
				prd.IFavorite = idFvrPrd.Contains(prd.MaSp);
			}
			return View(dbsanpham);
        }
    }
}
