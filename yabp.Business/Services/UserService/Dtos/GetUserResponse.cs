namespace yabp.Business.Services.UserService.Dtos;

public class GetUserResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string About { get; set; }
    public string ProfilePictureUrl { get; set; }

    public DateTime? BirthDate { get; set; }
}