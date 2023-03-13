using Entities.Base;
using Entities.UniqueRelations;

namespace DataAccess.Repositories.Relations.Interfaces;

public interface IPostsEditorsRepository
{
    public Task<IList<PostEdits>> GetAllAsync();
    public Task<IList<Post>> GetPostsByEditorIdAsync(int userId);
    public Task<IList<User>> GetUserByPostIdAsync(int postId);

    public Task<bool> AddAsync(PostEdits entity);
    public Task<bool> AddAsync(int userId, int postId);

    public Task<bool> DeleteAsync(PostEdits entity);
    public Task<bool> DeleteAsync(int userId, int postId);

    public Task<int> DeleteRelationsByEditorIdAsync(int userId);
    public Task<int> DeleteRelationsByPostId(int postId);
}