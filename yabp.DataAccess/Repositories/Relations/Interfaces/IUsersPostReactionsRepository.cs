using yabp.Entities.Base;
using yabp.Entities.Relations;

namespace yabp.DataAccess.Repositories.Relations.Interfaces;

public interface IUsersPostReactionsRepository
{
    public Task<IList<UsersPostReactions>> GetAllAsync();
    public Task<IList<Post>> GetReactedPostsByUserIdAsync(int userId);
    public Task<IList<User>> GetReactedUsersByPostIdAsync(int postId);  

    public Task<int> AddAsync(UsersPostReactions entity);
    public Task<int> AddAsync(int userId, int postId);

    public Task<int> DeleteAsync(UsersPostReactions entity);
    public Task<int> DeleteAsync(int userId, int postId);

    public Task<int> DeleteAllPostReactsByUserIdAsync(int userId);
    public Task<int> DeleteAllPostReactsByPostIdAsync(int postId);
}