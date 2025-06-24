using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdvertisementService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdvertisementDto>> GetAllAdvertisementsAsync()
        {
            var ads = await _context.Advertisements.ToListAsync();
            return _mapper.Map<IEnumerable<AdvertisementDto>>(ads);
        }

        public async Task<AdvertisementDto> GetAdvertisementByIdAsync(int id)
        {
            var ad = await _context.Advertisements.FindAsync(id);
            return ad == null ? null : _mapper.Map<AdvertisementDto>(ad);
        }

        public async Task<AdvertisementDto> CreateAdvertisementAsync(AdvertisementDto dto)
        {
            var entity = _mapper.Map<Advertisement>(dto);
            _context.Advertisements.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdvertisementDto>(entity);
        }

        public async Task<AdvertisementDto> UpdateAdvertisementAsync(int id, AdvertisementDto dto)
        {
            var entity = await _context.Advertisements.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AdvertisementDto>(entity);
        }

        public async Task<bool> DeleteAdvertisementAsync(int id)
        {
            var entity = await _context.Advertisements.FindAsync(id);
            if (entity == null) return false;

            _context.Advertisements.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}