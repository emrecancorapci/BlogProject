using yabp.API.Extensions;
using yabp.Business.Services.PostService;
using yabp.Business.Services.PostService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace yabp.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService) =>
        _postService = postService;

    // GET
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _postService.GetAsync(id);

        if (response == null) return NotFound();

        return Ok(response);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll(string? orderBy, string? dateStart, string? dateEnd, string? search, int? skip, int? take)
    {
        var responseList = await _postService.GetAllAsync();

        if (!search.IsNullOrEmpty())
        {
            // TODO Doesn't work (yet)
            responseList = responseList.SearchPosts(search);
        }
        if (!dateStart.IsNullOrEmpty() || !dateEnd.IsNullOrEmpty())
        {
            responseList = responseList.DateBetween(dateStart, dateEnd);
        }
        if(!orderBy.IsNullOrEmpty())
        {
            responseList = responseList.OrderPostBy(orderBy);
        }
        if (skip is not null)
        {
            responseList = responseList.Skip((int)skip).ToList();
        }
        if (take is not null)
        {
            responseList = responseList.Take((int)take).ToList();
        }

        return Ok(responseList);
    }
    [HttpGet("~/api/Tags/{tagId:int:min(1)}/Posts")]
    public async Task<IActionResult> GetAllByTag(int tagId)
    {
        var responseList = await _postService.GetAllByTagIdAsync(tagId);

        return Ok(responseList);
    }
    [HttpGet("~/api/Categories/{categoryId:int:min(1)}/Posts")]
    public async Task<IActionResult> GetAllByCategory(int categoryId)
    {
        var responseList = await _postService.GetAllByCategoryIdAsync(categoryId);

        return Ok(responseList);
    }
    [HttpGet("~/api/Users/{id:int:min(1)}/Posts")]
    public async Task<IActionResult> GetPosts([FromRoute]int id)
    {
        var responseList = await _postService.GetAllByUserIdAsync(id);

        return Ok(responseList);
    }
    [HttpGet("~/api/Users/{id:int:min(1)}/EditedPosts")]
    public async Task<IActionResult> GetEditedPosts([FromRoute]int id)
    {
        var responseList = await _postService.GetAllByEditorIdAsync(id);

        return Ok(responseList);
    }
    [HttpGet("{id:int:min(1)}/IsExist")]
    public async Task<IActionResult> IsExist(int id)
    {
        var response = await _postService.IsExistAsync(id);

        return Ok(response);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Add(AddPostRequest request)
    {
        var affectedRows = await _postService.AddAsync(request);

        return Ok(affectedRows);
    }

    // PATCH
    [HttpPatch]
    public async Task<IActionResult> Update(UpdatePostRequest request)
    {
        // TODO : Wants categoryId. Find a way to change only modified variables.

        var affectedRows = await _postService.UpdateAsync(request);
        return Ok(affectedRows);
    }
    [HttpPatch("React")]
    public async Task<IActionResult> React(ReactionPostRequest request)
    {
        var affectedRows = await _postService.ReactAsync(request);

        return Ok(affectedRows);
    }

    // DELETE
    [Authorize]
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> Delete(int id)
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