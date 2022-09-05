using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.CommentService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService) => 
        _commentService = commentService;

    // GET
    [HttpGet("{id:int:min(1)}")]
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
    [HttpGet("~/api/Posts/{id:int:min(1)}/Comments")]
    public async Task<IActionResult> GetAllByPost(int id)
    {
        var responseList = await _commentService.GetAllByPostIdAsync(id);

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
    [HttpPost("")]
    public async Task<IActionResult> Add(AddCommentRequest request)
    {
        var affectedRows = await _commentService.AddAsync(request);

        return Ok(affectedRows);
    }

    // TODO : Update method must implemented

    // PATCH
    [HttpPatch("")]
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
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> Delete(int id)
    {
        var affectedRows = await _commentService.DeleteAsync(id);

        return Ok(affectedRows);
    }
}

