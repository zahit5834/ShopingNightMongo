using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Services.GaleryServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultGaleryComponentPartial : ViewComponent
    {
        private readonly IGaleryService _galeryService;

        public _DefaultGaleryComponentPartial(IGaleryService galeryService)
        {
            _galeryService = galeryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _galeryService.GetAllGaleryAsync();
            return View(values);
        }
    }

}

