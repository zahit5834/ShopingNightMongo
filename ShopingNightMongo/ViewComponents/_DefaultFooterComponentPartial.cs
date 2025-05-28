using Microsoft.AspNetCore.Mvc;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
