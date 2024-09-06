using Microsoft.AspNetCore.Mvc;
using yourlook.MenuKid;

namespace yourlook.ViewMenukid
{
    public class ViewColor:ViewComponent
    {
        private readonly IColor _cl;
        public ViewColor(IColor color)
        {
            _cl = color;
        }
        public IViewComponentResult Invoke()
        {
            var dbcolors = _cl.GetAllColor().OrderBy(X => X.ColorId);
            return View(dbcolors);
        }
    }
}
