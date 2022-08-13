using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.UserService;

public interface IUserService
{
    Task<int> AddUser(CreateUserRequest request);
    Task<int> UpdateUser(User task);
    Task DeleteUser(int id);
    Task<User?> GetUserById(int id);
    Task<ICollection<User>> GetUsersAsync();
    Task<bool> IsExist(int id);
    Task<UserValidationResponse?> ValidateUserAsync(string userName, string password);
    Task<int> GetUserIdByUsername(string userName);
    Task<bool> IsEmailExistAsync(string email);
}