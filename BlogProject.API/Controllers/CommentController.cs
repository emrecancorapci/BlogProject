using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.CommentService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(
        ICommentService commentService)
    {
        _commentService = commentService;
    }

    // GET
    [HttpGet("Get")]
    public async Task<IActionResult> Get(int id)
    {
        if (id == 0) return BadRequest();
        if (!await _commentService.IsExistAsync(id)) return NotFound();
        
        var response = await _commentService.GetAsync(id);

        return Ok(response);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var responseList = await _commentService.GetAllAsync();

        return Ok(responseList);
    }
    [HttpGet("GetAllByUser")]
    public async Task<IActionResult> GetAllByUser(int userId)
    {
        if (userId == 0) return BadRequest();
        
        var responseList = await _commentService.GetAllByUserIdAsync(userId);

        return Ok(responseList);
    }
    [HttpGet("GetAllByPost")]
    public async Task<IActionResult> GetAllByPost(int userId)
    {
        if (userId == 0) return BadRequest();
        
        var responseList = await _commentService.GetAllByPostIdAsync(userId);

        return Ok(responseList);
    }
    [HttpGet("GetChildren")]
    public async Task<IActionResult> GetChildren(int userId)
    {
        if (userId == 0) return BadRequest();
        
        var responseList = await _commentService.GetChildrenAsync(userId);

        return Ok(responseList);
    }
    [HttpGet("IsExist")]
    public async Task<IActionResult> IsExist(int postId)
    {
        if (postId == 0) return BadRequest();
        
        var response = await _commentService.IsExistAsync(postId);

        return Ok(response);
    }

    // POST
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddCommentRequest request)
    {
        var affectedRows = await _commentService.AddAsync(request);

        return Ok(affectedRows);
    }

    // PATCH
    [HttpPatch("UpdateContent")]
    public async Task<IActionResult> UpdateContent(UpdateCommentContentRequest request)
    {
        var affectedRows = await _commentService.UpdateContentAsync(request);

        return Ok(affectedRows);
    }
    [HttpPatch("React")]
    public async Task<IActionResult> React(ReactionCommentRequest request)
    {
        var affectedRows = await _commentService.ReactAsync(request);

        return Ok(affectedRows);
    }

    // DELETE
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int postId)
    {
        var affectedRows = await _commentService.DeleteAsync(postId);

        return Ok(affectedRows);
    }
}

