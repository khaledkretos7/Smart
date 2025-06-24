using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SmartResidenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostDto dto)
        {
            var post = await _postService.CreatePostAsync(dto);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostDto dto)
        {
            var post = await _postService.UpdatePostAsync(id, dto);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Post deleted successfully" });
        }
    }
}
