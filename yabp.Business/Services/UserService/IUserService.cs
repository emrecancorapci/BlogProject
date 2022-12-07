using yabp.Business.Services.UserService.Dtos;

namespace yabp.Business.Services.UserService;

public interface IUserService
{
    Task<int> AddAsync(AddUserRequest request);
    Task<int> UpdateAsync(UpdateUserRequest request);
    Task<int> DeleteAsync(int id);
    Task<GetUserResponse?> GetAsync(int id);
    Task<IList<GetUserResponse>> GetAllAsync();
    Task<bool> IsExistAsync(int id);
    Task<UserValidationResponse?> ValidateUserAsync(UserValidationRequest request);
    Task<int> GetUserIdByUsername(string userName);
    Task<bool> IsEmailExistAsync(string email);
}