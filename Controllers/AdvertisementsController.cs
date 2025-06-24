using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SmartResidenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementsController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ads = await _advertisementService.GetAllAdvertisementsAsync();
            return Ok(ads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ad = await _advertisementService.GetAdvertisementByIdAsync(id);
            if (ad == null) return NotFound();
            return Ok(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementDto dto)
        {
            var ad = await _advertisementService.CreateAdvertisementAsync(dto);
            return Ok(ad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AdvertisementDto dto)
        {
            var ad = await _advertisementService.UpdateAdvertisementAsync(id, dto);
            if (ad == null) return NotFound();
            return Ok(ad);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _advertisementService.DeleteAdvertisementAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Advertisement deleted successfully" });
        }
    }
}
