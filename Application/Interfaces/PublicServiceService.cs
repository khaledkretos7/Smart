using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PublicServiceService : IPublicServiceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PublicServiceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Categories
        public async Task<IEnumerable<PublicServiceCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.PublicServiceCategories.ToListAsync();
            return _mapper.Map<IEnumerable<PublicServiceCategoryDto>>(categories);
        }

        public async Task<PublicServiceCategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.PublicServiceCategories.FindAsync(id);
            return category == null ? null : _mapper.Map<PublicServiceCategoryDto>(category);
        }

        public async Task<PublicServiceCategoryDto> CreateCategoryAsync(PublicServiceCategoryDto dto)
        {
            var entity = _mapper.Map<PublicServiceCategory>(dto);
            _context.PublicServiceCategories.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PublicServiceCategoryDto>(entity);
        }

        public async Task<PublicServiceCategoryDto> UpdateCategoryAsync(int id, PublicServiceCategoryDto dto)
        {
            var entity = await _context.PublicServiceCategories.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PublicServiceCategoryDto>(entity);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var entity = await _context.PublicServiceCategories.FindAsync(id);
            if (entity == null) return false;

            _context.PublicServiceCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Services
        public async Task<IEnumerable<PublicServiceDto>> GetAllServicesAsync()
        {
            var services = await _context.PublicServices.ToListAsync();
            return _mapper.Map<IEnumerable<PublicServiceDto>>(services);
        }

        public async Task<PublicServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _context.PublicServices.FindAsync(id);
            return service == null ? null : _mapper.Map<PublicServiceDto>(service);
        }

        public async Task<PublicServiceDto> CreateServiceAsync(PublicServiceDto dto)
        {
            var entity = _mapper.Map<PublicService>(dto);
            _context.PublicServices.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PublicServiceDto>(entity);
        }

        public async Task<PublicServiceDto> UpdateServiceAsync(int id, PublicServiceDto dto)
        {
            var entity = await _context.PublicServices.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return _mapper.Map<PublicServiceDto>(entity);
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var entity = await _context.PublicServices.FindAsync(id);
            if (entity == null) return false;

            _context.PublicServices.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}