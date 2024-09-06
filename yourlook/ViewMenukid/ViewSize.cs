using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
    public class ViewSize:ViewComponent
    {
        private readonly ISize _s;
        public ViewSize(ISize size)
        {
            _s = size;
        }
        public IViewComponentResult Invoke()
        {
            var dbsize = _s.GetAllSize().OrderBy(X => X.SizeId);
            return View(dbsize);
        }
    }
}
