using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.CommentService;

public interface ICommentService
{
    Task<int> AddCommentAsync(AddCommentRequest request);
    Task<int> UpdateCommentAsync(Comment comment);
    Task<int> UpdateCommentContentAsync(UpdateCommentContentRequest request);

    Task<int> DeleteCommentAsync(int commentId);
    Task<int> DeleteCommentAllAsync(int postId);
    Task<int> DeleteCommentAllByUserAsync(int userId);
    
    Task<int> GetCommentsAsync();
    Task<int> GetCommentByIdAsync(int commentId);
    Task<int> GetCommentCountAsync(int postId);
    Task<int> GetCommentCountByUserAsync(int userId);

    Task<int> ReactionComment(ReactionCommentRequest request);

    Task<int> IsExist(int commentId);
    
}