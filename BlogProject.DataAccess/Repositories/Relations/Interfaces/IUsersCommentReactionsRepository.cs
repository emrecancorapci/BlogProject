using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;

namespace BlogProject.DataAccess.Repositories.Relations.Interfaces;

public interface IUsersCommentReactionsRepository
{
    public Task<IList<UsersCommentReactions>> GetAllAsync();
    public Task<IList<Comment>> GetReactedCommentsByUserIdAsync(int userId);
    public Task<IList<User>> GetReactedUsersByCommentIdAsync(int commentId);

    public Task<int> AddAsync(UsersCommentReactions entity);
    public Task<int> AddAsync(int userId, int commentId);

    public Task<int> DeleteAsync(UsersCommentReactions entity);
    public Task<int> DeleteAsync(int userId, int commentId);

    public Task<int> DeleteAllCommentReactsByUserIdAsync(int userId);
    public Task<int> DeleteAllCommentReactsByCommentIdAsync(int commentId);
}