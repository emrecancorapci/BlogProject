using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.Business.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public PostController(
            IPostService postService,
            IUserService userService,
            ICommentService commentService)
        {
            _postService = postService;
            _userService = userService;
            _commentService = commentService;
        }

        // GET

        [HttpGet("Get", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();
            if (!await _postService.IsExist(id)) return NotFound();
            
            var post = await _postService.GetPostById(id);

            return Ok(post);
        }

        
        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var post = await _postService.GetPostsAsync();

            return Ok(post);
        }

        [HttpGet("GetAllByUser", Name = "GetAllByUser")]
        public async Task<IActionResult> GetAllByUser(int userId)
        {
            if (userId == 0) return BadRequest();
            
            var post = await _postService.GetPostsByUserId(userId);

            return Ok(post);
        }

        [HttpGet("GetAllByTag", Name = "GetAllByTag")]
        public async Task<IActionResult> GetAllByTag(int tagId)
        {
            if (tagId == 0) return BadRequest();
            
            var post = await _postService.GetPostsByTagId(tagId);

            return Ok(post);
        }

        [HttpGet("GetAllByCategory", Name = "GetAllByCategory")]
        public async Task<IActionResult> GetAllByCategory(int categoryId)
        {
            if (categoryId == 0) return BadRequest();
            
            var post = await _postService.GetPostsByCategoryId(categoryId);

            return Ok(post);
        }

        [HttpGet("GetAllByEditor", Name = "GetAllByEditor")]
        public async Task<IActionResult> GetAllByEditor(int editorId)
        {
            if (editorId == 0) return BadRequest();
            
            var post = await _postService.GetPostsByEditorId(editorId);

            return Ok(post);
        }

        [HttpGet("IsExist", Name = "IsPostExist")]
        public async Task<IActionResult> IsExist(int postId)
        {
            if (postId == 0) return BadRequest();
            
            var post = await _postService.IsExist(postId);

            return Ok(post);
        }

        // POST

        [HttpPost("Add",Name = "Add")]
        public async Task<IActionResult> Add(AddPostRequest request)
        {
            var post = await _postService.AddPost(request);

            return Ok(post);
        }

        // PATCH
        
        [HttpPatch("UpdateContent", Name = "UpdateContent")]
        public async Task<IActionResult> UpdateContent(UpdatePostContentRequest request)
        {
            var post = await _postService.UpdatePostContent(request);

            return Ok(post);
        }

        [HttpPatch("Reaction", Name = "Reaction")]
        public async Task<IActionResult> Reaction(ReactionPostRequest request)
        {
            var post = await _postService.ReactionPost(request);

            return Ok(post);
        }

        // DELETE

        [HttpDelete("Delete", Name = "Delete")]
        public async Task<IActionResult> Delete(int postId)
        {
            var post = await _postService.DeletePost(postId);

            return Ok(post);
        }
    }
}
