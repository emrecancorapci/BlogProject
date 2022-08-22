using AutoMapper;
using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Extensions;
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

    public async Task<int> AddAsync(AddUserRequest request)
    {
        var user = mapper.Map<User>(request);

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Role = "user";
        user.Created = DateTime.Now.SetKindUtc();
        user.Modified = DateTime.Now.SetKindUtc();

        var userId = await userRepository.AddAsync(user);
        return userId;
    }

    public async Task<int> UpdateAsync(User user)
    {
        user.Modified = DateTime.Now.SetKindUtc();
        
        return await userRepository.UpdateAsync(user);
    }

    public async Task<int> DeleteAsync(int id) => 
        await userRepository.DeleteAsync(id);

    public async Task<GetUserResponse?> GetAsync(int id)
    {
        var entity = await userRepository.GetAsync(id);
        if (entity == null) return null;

        var response = mapper.Map<GetUserResponse>(entity);

        return response;
    }

    public async Task<IList<GetUserResponse>> GetAllAsync()
    {
        var entityList = await userRepository.GetAllAsync();
        var responseList = entityList
            .OrderByDescending(user => user.Created)
            .Select(user => mapper.Map<GetUserResponse>(user))
            .ToList();

        return responseList;
    }

    public async Task<bool> IsExistAsync(int id) =>
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