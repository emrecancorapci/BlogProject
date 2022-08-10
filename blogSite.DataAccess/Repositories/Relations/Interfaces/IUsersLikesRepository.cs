using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;

namespace BlogProject.DataAccess.Repositories.Relations.Interfaces;

public interface IUsersLikesRepository
{
    public Task<IList<UsersLikes>> GetAllAsync();
    public Task<IList<Post>> GetLikesByUserIdAsync(int userId);
    public Task<IList<User>> GetUsersByPostIdAsync(int postId);

    public Task<bool> AddAsync(UsersLikes entity);
    public Task<bool> AddAsync(int userId, int postId);

    public Task<bool> DeleteAsync(UsersLikes entity);
    public Task<bool> DeleteAsync(int userId, int postId);

    public Task<int> DeleteUsersAllAsync(int userId);
    public Task<int> DeletePostAllAsync(int postId);
}