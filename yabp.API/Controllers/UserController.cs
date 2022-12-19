using yabp.Business.Services.AuthenticationService;
using yabp.Business.Services.PostService;
using yabp.Business.Services.UserService;
using yabp.Business.Services.UserService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace yabp.API.Controllers;

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

        if (response is null) return NotFound();

        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserValidationRequest request)
    {
        var response = await _userService.ValidateUserAsync(request);

        if (response is null) return NotFound();

        var tokenResponse = await _jwtAuthenticationManager.GetJwtTokenAsync(response.UserName);

        if (tokenResponse is null) throw new Exception("Token is null");

        response.Token = tokenResponse;

        return Ok(response);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var responseList = await _userService.GetAllAsync();

        return Ok(responseList);
    }

    [HttpGet("IsExist")]
    public async Task<IActionResult> IsExist([FromQuery]int? id, [FromQuery]string? email)
    {
        if (id is not null)
            return Ok(await _userService.IsExistAsync((int)id));

        if (!email.IsNullOrEmpty())
            return Ok(await _userService.IsEmailExistAsync(email));

        return NotFound();
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

