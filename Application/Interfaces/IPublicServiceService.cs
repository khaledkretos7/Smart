using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPublicServiceService
    {
        // Categories
        Task<IEnumerable<PublicServiceCategoryDto>> GetAllCategoriesAsync();
        Task<PublicServiceCategoryDto> GetCategoryByIdAsync(int id);
        Task<PublicServiceCategoryDto> CreateCategoryAsync(PublicServiceCategoryDto dto);
        Task<PublicServiceCategoryDto> UpdateCategoryAsync(int id, PublicServiceCategoryDto dto);
        Task<bool> DeleteCategoryAsync(int id);

        // Services
        Task<IEnumerable<PublicServiceDto>> GetAllServicesAsync();
        Task<PublicServiceDto> GetServiceByIdAsync(int id);
        Task<PublicServiceDto> CreateServiceAsync(PublicServiceDto dto);
        Task<PublicServiceDto> UpdateServiceAsync(int id, PublicServiceDto dto);
        Task<bool> DeleteServiceAsync(int id);
    }
}
