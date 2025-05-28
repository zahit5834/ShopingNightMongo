using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Dtos.GaleryDtos;
using ShopingNightMongo.Services.GaleryServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.Controllers
{
    public class GaleryController : Controller
    {
        private readonly IGaleryService _galeryService;

        public GaleryController(IGaleryService galeryService)
        {
            _galeryService = galeryService;
        }

        public async Task<IActionResult> GaleryList()
        {
            var values = await _galeryService.GetAllGaleryAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateGalery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGalery(CreateGaleryDto createGaleryDto)
        {
            await _galeryService.CreateGaleryAsync(createGaleryDto);
            return RedirectToAction("GaleryList");
        }
        public async Task<IActionResult> DeleteGalery(string id)
        {
            await _galeryService.DeleteGaleryAsync(id);
            return RedirectToAction("GaleryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGalery(string id)
        {
            var value = await _galeryService.GetGaleryByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGalery(UpdateGaleryDto updateGaleryDto)
        {
            await _galeryService.UpdateGaleryAsync(updateGaleryDto);
            return RedirectToAction("GaleryList");


        }
    }
}