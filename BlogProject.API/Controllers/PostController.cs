using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.PostService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(Name = "GetPost")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPostById(id);

            return Ok(post);
        }

        [HttpPost(Name = "AddPost")]
        public async Task<IActionResult> AddPost(AddPostRequest request)
        {
            var post = await _postService.AddPost(request);

            return Ok(post);
        }
        
    }
}
