using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<AdvertisementDto>> GetAllAdvertisementsAsync();
        Task<AdvertisementDto> GetAdvertisementByIdAsync(int id);
        Task<AdvertisementDto> CreateAdvertisementAsync(AdvertisementDto dto);
        Task<AdvertisementDto> UpdateAdvertisementAsync(int id, AdvertisementDto dto);
        Task<bool> DeleteAdvertisementAsync(int id);
    }
}
