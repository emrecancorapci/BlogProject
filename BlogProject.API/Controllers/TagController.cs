using BlogProject.Business.Services.TagService;
using BlogProject.Business.Services.TagService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(int id)
    {
        if (id == 0) return BadRequest();
        if (!await _tagService.IsExistAsync(id)) return NotFound();
    
        var response = await _tagService.GetAsync(id);

        return Ok(response);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(TagData request)
    {
        var affectedRows = await _tagService.AddAsync(request);

        return Ok(affectedRows);
    }
}