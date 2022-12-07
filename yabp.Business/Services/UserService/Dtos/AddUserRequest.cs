namespace yabp.Business.Services.UserService.Dtos;

public class AddUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}