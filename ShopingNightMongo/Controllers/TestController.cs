using Microsoft.AspNetCore.Mvc;

namespace ShopingNightMongo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult LoadProductModal(string id)
        {
            return ViewComponent("_TestModalComponentPartial", new { id });
        }
    }
}
