using Microsoft.AspNetCore.Mvc;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
