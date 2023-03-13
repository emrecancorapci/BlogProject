using Entities.Base;
using Entities.Relations;

namespace DataAccess.Repositories.Relations.Interfaces;

public interface IPostsTagsRepository
{
    public Task<IList<PostsTags>> GetAllAsync();
    public Task<IList<Post>> GetPostsByTagIdAsync(int tagId);
    public Task<IList<Tag>> GetTagsByPostIdAsync(int postId);

    public Task<bool> AddAsync(PostsTags entity);
    public Task<bool> AddAsync(int tagId, int postId);

    public Task<bool> DeleteAsync(PostsTags entity);
    public Task<bool> DeleteAsync(int tagId, int postId);

    public Task<int> DeleteTagAllAsync(int tagId);
    public Task<int> DeletePostAllAsync(int userId);
}