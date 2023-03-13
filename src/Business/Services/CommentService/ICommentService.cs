using Business.Services.CommentService.Dtos;
using Entities.Base;

namespace Business.Services.CommentService;

public interface ICommentService
{
    Task<int> AddAsync(AddCommentRequest request);
    Task<int> UpdateAsync(Comment comment);
    Task<int> UpdateContentAsync(UpdateCommentContentRequest request);

    Task<int> DeleteAsync(int commentId);
    Task<int> DeleteAllByPostIdAsync(int postId);
    Task<int> DeleteAllByUserIdAsync(int userId);
    
    Task<GetCommentResponse?> GetAsync(int commentId);
    Task<List<GetCommentResponse>> GetAllAsync();
    Task<List<GetCommentResponse>> GetAllByUserIdAsync(int userId);
    Task<List<GetCommentResponse>> GetAllByPostIdAsync(int postId);
    Task<List<GetCommentResponse>> GetChildrenAsync(int commentId);
    Task<int> GetCountByPostIdAsync(int postId);
    Task<int> GetCountByUserIdAsync(int userId);

    Task<int> ReactAsync(ReactionCommentRequest request);

    Task<bool> IsExistAsync(int commentId);
    
}