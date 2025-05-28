using Microsoft.AspNetCore.Mvc;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}