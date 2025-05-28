using Microsoft.AspNetCore.Mvc;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}

