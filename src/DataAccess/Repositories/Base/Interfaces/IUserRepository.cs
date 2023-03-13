using Entities.Base;

namespace DataAccess.Repositories.Base.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> ValidateUserAsync(string username);
    public Task<bool> IsEmailExist(string email);
}
