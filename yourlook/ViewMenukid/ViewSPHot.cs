using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
    public class ViewSPHot:ViewComponent
    {
		private readonly YourlookContext _context;
        private readonly ISanPhamHot _spHot;
		public ViewSPHot(ISanPhamHot cLSanPhamHot,YourlookContext context)
        {
            _spHot = cLSanPhamHot;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
			var idkh = HttpContext.Session.GetInt32("userid");
            var idFvrPrd = new List<int>();
            if (idkh != null) 
            { 
                idFvrPrd=_context.DbFavoriteProducts.AsNoTracking().Where(x=>x.MaKh==idkh.Value).Select(x=>x.MaSp).ToList();
            }
			var db5SanPhamHot = _spHot.GetAllSanPhamHot().OrderByDescending(X => X.LuotXem).Take(10);
            foreach (var prd in db5SanPhamHot)
            {
                prd.IFavorite=idFvrPrd.Contains(prd.MaSp);
            }
            return View(db5SanPhamHot);
        }
    }
}
