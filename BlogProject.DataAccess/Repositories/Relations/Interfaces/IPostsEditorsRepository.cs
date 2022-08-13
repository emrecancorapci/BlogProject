using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;

namespace BlogProject.DataAccess.Repositories.Relations.Interfaces;

public interface IPostsEditorsRepository
{
    public Task<IList<PostsEditors>> GetAllAsync();
    public Task<IList<Post>> GetPostsByEditorIdAsync(int userId);
    public Task<IList<User>> GetUserByPostIdAsync(int postId);

    public Task<bool> AddAsync(PostsEditors entity);
    public Task<bool> AddAsync(int userId, int postId);

    public Task<bool> DeleteAsync(PostsEditors entity);
    public Task<bool> DeleteAsync(int userId, int postId);

    public Task<int> DeleteEditorAllAsync(int userId);
    public Task<int> DeletePostAllAsync(int postId);
}