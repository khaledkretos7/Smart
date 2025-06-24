using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PostService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post == null ? null : _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> CreatePostAsync(PostDto dto)
        {
            var entity = _mapper.Map<Post>(dto);
            _context.Posts.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDto>(entity);
        }

        public async Task<PostDto> UpdatePostAsync(int id, PostDto dto)
        {
            var entity = await _context.Posts.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDto>(entity);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var entity = await _context.Posts.FindAsync(id);
            if (entity == null) return false;

            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}