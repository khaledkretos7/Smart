using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartResidenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicServicesController : ControllerBase
    {
        private readonly IPublicServiceService _publicServiceService;

        public PublicServicesController(IPublicServiceService publicServiceService)
        {
            _publicServiceService = publicServiceService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _publicServiceService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost("categories")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(PublicServiceCategoryDto dto)
        {
            var category = await _publicServiceService.CreateCategoryAsync(dto);
            return Ok(category);
        }

        [HttpPut("categories/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(int id, PublicServiceCategoryDto dto)
        {
            var category = await _publicServiceService.UpdateCategoryAsync(id, dto);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpDelete("categories/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _publicServiceService.DeleteCategoryAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Category deleted successfully" });
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _publicServiceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpPost("services")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateService(PublicServiceDto dto)
        {
            var service = await _publicServiceService.CreateServiceAsync(dto);
            return Ok(service);
        }

        [HttpPut("services/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateService(int id, PublicServiceDto dto)
        {
            var service = await _publicServiceService.UpdateServiceAsync(id, dto);
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpDelete("services/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _publicServiceService.DeleteServiceAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Service deleted successfully" });
        }
    }
}
