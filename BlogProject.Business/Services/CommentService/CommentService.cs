using AutoMapper;
using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUsersCommentReactionsRepository _usersCommentReactionsRepository;
    private readonly IMapper _mapper;

    public CommentService(
        ICommentRepository commentRepository,
        IUsersCommentReactionsRepository usersCommentReactionsRepository,
        IMapper mapper)
    {
        _commentRepository = commentRepository;
        _usersCommentReactionsRepository = usersCommentReactionsRepository;
        _mapper = mapper;

    }

    public async Task<int> AddCommentAsync(AddCommentRequest request)
    {
        var comment = _mapper.Map<Comment>(request);

        comment.Created = DateTime.Now;
        comment.Updated = DateTime.Now;

        var commentId = await _commentRepository.Add(comment);
        return commentId;
    }

    public async Task<int> UpdateCommentAsync(Comment comment)
    {
        comment.Updated = DateTime.Now;

        return await _commentRepository.Update(comment);
    }

    public async Task<int> UpdateCommentContentAsync(UpdateCommentContentRequest request)
    {
        var comment = _mapper.Map<Comment>(request);

        comment.Updated = DateTime.Now;

        return await _commentRepository.Update(comment);
    }

    public async Task<int> DeleteCommentAsync(int commentId) => 
        await _commentRepository.DeleteAsync(commentId);

    public async Task<int> DeleteCommentAllAsync(int postId)
    {
        var comments = await _commentRepository.GetAllAsync();
        int affectedRows = 0;
            
        comments.ToList()
            .ForEach(async comment =>
        {
            if (comment.PostId == postId)
            {
                affectedRows++;
                await _commentRepository.DeleteAsync(comment.Id);
            }
        });

        return affectedRows;
    }

    public async Task<int> DeleteCommentAllByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetCommentsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetCommentByIdAsync(int commentId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetCommentCountAsync(int postId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetCommentCountByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> ReactionComment(ReactionCommentRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<int> IsExist(int commentId)
    {
        throw new NotImplementedException();
    }
}