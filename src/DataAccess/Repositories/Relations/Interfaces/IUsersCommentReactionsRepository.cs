using Entities.Base;
using Entities.Relations;

namespace DataAccess.Repositories.Relations.Interfaces;

public interface IUsersCommentReactionsRepository
{
    public Task<IList<UsersCommentReactions>> GetAll();
    public Task<IList<Comment>> GetReactedCommentsByUserId(int userId);
    public Task<IList<User>> GetReactedUsersByCommentId(int commentId);

    public Task<int> AddAsync(UsersCommentReactions entity);
    public Task<int> AddAsync(int userId, int commentId);
    
    public Task<int> DeleteAsync(int userId, int commentId);

    public Task<int> DeleteCommentsByUserId(int userId);
    public Task<int> DeleteReactsByCommentIdAsync(int commentId);
}