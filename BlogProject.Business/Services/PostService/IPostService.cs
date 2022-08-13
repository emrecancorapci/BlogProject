using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.PostService;

public interface IPostService
{
    Task<int> AddPost(AddPostRequest request);
    Task<int> UpdatePost(Post post);
    Task<int> UpdatePostContent(UpdatePostContentRequest request);
    Task DeletePost(int id);
    Task<bool> IsExist(int postId);
    
    Task<Post?> GetPostById(int id);
    Task<IList<Post>> GetPostsAsync();
    Task<IList<Post>> GetPostsByEditorIdAsync(int editorId);
    Task<IList<Post>> GetPostsByUserId(int userId);
    Task<IList<Post>> GetPostsByTagId(int tagId);
    Task<IList<Post>> GetPostsByCategoryId(int categoryId);
    Task<IList<Post>> GetPostsBySearch(string search);

    public Task<int> ReactionPost(ReactionPostRequest request);

    Task<bool> AddPostEditor(int postId, int editorId);
    Task<bool> DeletePostEditor(int postId, int editorId);
    Task<int> DeletePostEditorAll(int editorId);


}