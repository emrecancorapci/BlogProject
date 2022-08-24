using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.UserService;

public interface IUserService
{
    Task<int> AddAsync(AddUserRequest request);
    Task<int> UpdateAsync(UpdateUserRequest request);
    Task<int> DeleteAsync(int id);
    Task<GetUserResponse?> GetAsync(int id);
    Task<IList<GetUserResponse>> GetAllAsync();
    Task<bool> IsExistAsync(int id);
    Task<UserValidationResponse?> ValidateUserAsync(string username, string password);
    Task<int> GetUserIdByUsername(string userName);
    Task<bool> IsEmailExistAsync(string email);
}