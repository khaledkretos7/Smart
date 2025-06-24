using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<PostDto> CreatePostAsync(PostDto dto);
        Task<PostDto> UpdatePostAsync(int id, PostDto dto);
        Task<bool> DeletePostAsync(int id);
    }
}
