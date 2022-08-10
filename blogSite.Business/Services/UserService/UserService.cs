using AutoMapper;
using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    
    public UserService(IUserRepository userRepository,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<int> AddUser(CreateUserRequest request)
    {
        var user = mapper.Map<User>(request);

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Role = "user";
        user.Created = DateTime.Now;
        user.Modified = DateTime.Now;

        var userId = await userRepository.Add(user);
        return userId;
    }

    public async Task<int> UpdateUser(User user)
    {
        user.Modified = DateTime.Now;
        
        return await userRepository.Update(user);
    }

    public async Task DeleteUser(int id) =>
        await userRepository.DeleteAsync(id);

    public async Task<User?> GetUserById(int id) =>
        await userRepository.GetAsync(id);

    public async Task<ICollection<User>> GetUsersAsync() =>
        await userRepository.GetAllAsync();

    public async Task<bool> IsExist(int id) =>
        await userRepository.IsExist(id);

    public async Task<UserValidationResponse?> ValidateUserAsync(string userName, string password)
    {
        var user = await userRepository.ValidateUser(userName);
        bool isVerified = BCrypt.Net.BCrypt.Verify(password, user.Password);

        if (user == null || !isVerified) return null;

        var response = mapper.Map<UserValidationResponse>(user);
        return response;
    }

    public async Task<bool> IsUserNameExistAsync(string userName) =>
        (await userRepository.ValidateUser(userName)) != null;

    public async Task<bool> IsEmailExistAsync(string email) => 
        await userRepository.IsEmailExist(email);
    
    public async Task<int> GetUserIdByUsername(string userName) =>
        (await userRepository.ValidateUser(userName)).Id;
}