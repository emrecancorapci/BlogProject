using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.CommentService;

public class CommentService : ICommentService
{
    public Task<int> AddCommentAsync(AddCommentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateCommentAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateCommentContentAsync(UpdateCommentContentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteCommentAsync(int commentId)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteCommentAllAsync(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteCommentAllByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCommentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCommentByIdAsync(int commentId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCommentCountAsync(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCommentCountByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<int> ReactionComment(ReactionCommentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<int> IsExist(int commentId)
    {
        throw new NotImplementedException();
    }
}