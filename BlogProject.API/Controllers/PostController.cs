using BlogProject.API.Extensions;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.PostService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService) =>
        _postService = postService;

    // GET
    [HttpGet("Get")]
    public async Task<IActionResult> Get(int id)
    {
        
        
        var response = await _postService.GetAsync(id);

        if(response == null) return NotFound();

    [HttpGet("")]
    public async Task<IActionResult> GetAll(string? orderBy, string? dateStart, string? dateEnd, string? search, int? skip, int? take)
    public async Task<IActionResult> GetAll()
    public async Task<IActionResult> GetAll()
    {
        if (search != null)
        {
            // TODO Doesn't work (yet)
            responseList.SearchPosts(search);
        }
        if (dateStart != null || dateEnd != null)
        {
            responseList.DateBetween(dateStart, dateEnd);
        }
        if(orderBy != null)
        {
            responseList = responseList.OrderPostBy(orderBy);
        }
        if (skip != null)
        {
            responseList = responseList.Skip((int)skip).ToList();
        }
        if (take != null)
        {
            responseList = responseList.Take((int)take).ToList();
        }

        return Ok(responseList);
    }
    [HttpGet("~/api/Tags/{tagId:int:min(1)}/Posts")]
    [HttpGet("GetAllByTag")]
    [HttpGet("GetAllByTag")]
    public async Task<IActionResult> GetAllByTag(int tagId)
    {
        var responseList = await _postService.GetAllByTagIdAsync(tagId);

        return Ok(responseList);
    }
    [HttpGet("~/api/Categories/{categoryId:int:min(1)}/Posts")]
    public async Task<IActionResult> GetAllByCategory(int categoryId)
    {
        var responseList = await _postService.GetAllByCategoryIdAsync(categoryId);

    [HttpGet("{id:int:min(1)}/IsExist")]
    public async Task<IActionResult> IsExist(int id)
    {
        var response = await _postService.IsExistAsync(id);
        var responseList = await _postService.GetAllByEditorIdAsync(editorId);

        return Ok(responseList);
    }
    [HttpGet("IsExist")]
    [HttpPost("")]
    {
        if (postId == 0) return BadRequest();
        
        var response = await _postService.IsExistAsync(postId);
        var responseList = await _postService.GetAllByEditorIdAsync(editorId);

        return Ok(responseList);
    // PATCH
    [HttpPatch("")]
    [HttpPost("Add")]
    {
        if (postId == 0) return BadRequest();
        
        var response = await _postService.IsExistAsync(postId);

        return Ok(response);
        return Ok(affectedRows);
    }

    // PATCH
    [HttpPatch("UpdateContent")]
    public async Task<IActionResult> UpdateContent(UpdatePostContentRequest request)
    {
        var affectedRows = await _postService.UpdateContentAsync(request);
        // TODO : Wants categoryId. Find a way to change only modified variables.
    [HttpDelete(""), Authorize]
    public async Task<IActionResult> Delete(int postId)
    }


    // PATCH
    [HttpPatch("UpdateContent")]
    public async Task<IActionResult> UpdateContent(UpdatePostContentRequest request)
    {
        var affectedRows = await _postService.UpdateContentAsync(request);
        // TODO : Wants categoryId. Find a way to change only modified variables.
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int postId)
    [HttpPatch("React")]
    public async Task<IActionResult> React(ReactionPostRequest request)
    {
        var affectedRows = await _postService.ReactAsync(request);

        return Ok(affectedRows);
    }

    // DELETE
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int postId)
    {
        var affectedRows = await _postService.DeleteAsync(id);

        return Ok(affectedRows);
    }

    // DEPRECATED 

    //[HttpPatch("UpdateContent")]
    //public async Task<IActionResult> UpdateContent(UpdatePostContentRequest request)
    //{
    //    var affectedRows = await _postService.UpdateContentAsync(request);
    //    return Ok(affectedRows);
    //}

}