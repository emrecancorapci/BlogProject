namespace BlogProject.Business.Services.UserService.Dtos;

public class UserValidationResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}
