using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.PostService;

public interface IPostService
{
    Task<int> AddPost(AddPostRequest request);
    Task<int> UpdatePost(Post post);
    Task<int> UpdatePostContent(UpdatePostContentRequest request);
    Task<int> DeletePost(int id);
    Task<bool> IsExist(int postId);
    
    Task<GetPostResponse?> GetPostById(int id);
    Task<IList<GetPostResponse>> GetPostsAsync();
    Task<IList<GetPostResponse>> GetPostsByEditorId(int editorId);
    Task<IList<GetPostResponse>> GetPostsByUserId(int userId);
    Task<IList<GetPostResponse>> GetPostsByTagId(int tagId);
    Task<IList<GetPostResponse>> GetPostsByCategoryId(int categoryId);
    Task<IList<GetPostResponse>> GetPostsBySearch(string search);

    Task<int> ReactionPost(ReactionPostRequest request);

    Task<bool> AddPostEditor(int postId, int editorId);
    Task<bool> DeletePostEditor(int postId, int editorId);
    Task<int> DeletePostEditorAll(int editorId);


}