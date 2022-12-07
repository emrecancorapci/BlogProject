using yabp.Business.Services.CategoryService;
using yabp.Business.Services.CategoryService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace yabp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) => 
        _categoryService = categoryService;

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> Get(int id)
    {
        if (id == 0) return BadRequest();
        if (!await _categoryService.IsExistAsync(id)) return NotFound();
    
        var response = await _categoryService.GetAsync(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategoryData request)
    {
        var affectedRows = await _categoryService.AddAsync(request);

        return Ok(affectedRows);
    }
}