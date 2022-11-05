using BlogProject.Business.Services.AuthenticationService;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.UserService;
using BlogProject.Business.Services.UserService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogProject.API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

    public UserController(
        IUserService userService,
        IJwtAuthenticationManager jwtAuthenticationManager) =>
        (_userService, _jwtAuthenticationManager) =
        (userService, jwtAuthenticationManager);

    // GET
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _userService.GetAsync(id);

        if (response == null) return NotFound();

        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserValidationRequest request)
    {
        var response = await _userService.ValidateUserAsync(request);

        if (response == null) return NotFound();

        var tokenResponse = await _jwtAuthenticationManager.GetJwtTokenAsync(response.UserName);

        if (tokenResponse == null) throw new Exception("Token is null");

        response.Token = tokenResponse;

        return Ok(response);
    }
    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var responseList = await _userService.GetAllAsync();

        return Ok(responseList);
    }

    [HttpGet("IsExist")]
    public async Task<IActionResult> IsExist(int? id, string? email)
    {
        var response = false;
        
        if (id != null)
        {
            response = await _userService.IsExistAsync((int)id);
        }
        if (!email.IsNullOrEmpty())
        {
            response = await _userService.IsEmailExistAsync(email);
        }

        return Ok(response);
    }

    // NO NEED
    //[HttpGet("GetUserIdByUsername")]
    //public async Task<IActionResult> GetUserIdByUsername(string username)
    //{
    //    var response = await _userService.GetUserIdByUsername(username);

    //    return Ok(response);
    //}

    // POST
    [HttpPost]
    public async Task<IActionResult> Add(AddUserRequest request)
    {
        var affectedRows = await _userService.AddAsync(request);

        return Ok(affectedRows);
    }

    // PATCH
    [Authorize]
    [HttpPatch]
    public async Task<IActionResult> Update(UpdateUserRequest request)
    {
        var affectedRows = await _userService.UpdateAsync(request);

        return Ok(affectedRows);
    }

    // DELETE
    [Authorize]
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> Delete(int id)
    {
        var affectedRows = await _userService.DeleteAsync(id);

        return Ok(affectedRows);
    }
}

