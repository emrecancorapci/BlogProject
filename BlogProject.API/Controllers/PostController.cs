using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.PostService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers;

[Authorize]
[Route("api/[controller]s")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService) =>
        _postService = postService;

    // GET
    [AllowAnonymous]
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        if (!await _postService.IsExistAsync(id)) return NotFound();
        
        var response = await _postService.GetAsync(id);

        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var responseList = await _postService.GetAllAsync();

        return Ok(responseList);
    }
    [HttpGet("GetAllByTag")]
    public async Task<IActionResult> GetAllByTag(int tagId)
    {
        if (tagId == 0) return BadRequest();
        
        var responseList = await _postService.GetAllByTagIdAsync(tagId);

        return Ok(responseList);
    }
    [HttpGet("GetAllByCategory")]
    public async Task<IActionResult> GetAllByCategory(int categoryId)
    {
        if (categoryId == 0) return BadRequest();
        
        var responseList = await _postService.GetAllByCategoryIdAsync(categoryId);

        return Ok(responseList);
    }
    [HttpGet("IsExist/{id:int}")]
    public async Task<IActionResult> IsExist(int id)
    {
        if (id == 0) return BadRequest();
        
        var response = await _postService.IsExistAsync(id);

        return Ok(response);
    }

    // POST
    [AllowAnonymous]
    [HttpPost("")]
    public async Task<IActionResult> Add(AddPostRequest request)
    {
        var affectedRows = await _postService.AddAsync(request);

        return Ok(affectedRows);
    }

    // PUT
    [HttpPut("")]
    public async Task<IActionResult> Update(UpdatePostRequest request)
    {
        var affectedRows = await _postService.UpdateAsync(request);
        return Ok(affectedRows);
    }

    // PATCH
    [HttpPatch("")]
    public async Task<IActionResult> UpdateContent(UpdatePostContentRequest request)
    {
        var affectedRows = await _postService.UpdateContentAsync(request);
        // TODO : Wants categoryId. Find a way to change only modified variables.
        return Ok(affectedRows);
    }
    [HttpPatch("React")]
    public async Task<IActionResult> React(ReactionPostRequest request)
    {
        var affectedRows = await _postService.ReactAsync(request);

        return Ok(affectedRows);
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var affectedRows = await _postService.DeleteAsync(id);

        return Ok(affectedRows);
    }
}