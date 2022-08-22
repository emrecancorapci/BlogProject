using AutoMapper;
using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Extensions;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;

namespace BlogProject.Business.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepo;
    private readonly IUsersCommentReactionsRepository _usersCommentReactionsRepo;
    private readonly IMapper _mapper;

    public CommentService(
        ICommentRepository commentRepo,
        IUsersCommentReactionsRepository usersCommentReactionsRepo,
        IMapper mapper)
    {
        _commentRepo = commentRepo;
        _usersCommentReactionsRepo = usersCommentReactionsRepo;
        _mapper = mapper;

    }

    // ADD
    public async Task<int> AddAsync(AddCommentRequest request)
    {
        var comment = _mapper.Map<Comment>(request);

        comment.Created = DateTime.Now.SetKindUtc();
        comment.Updated = DateTime.Now.SetKindUtc();

        var commentId = await _commentRepo.AddAsync(comment);
        return commentId;
    }

    // UPDATE
    public async Task<int> UpdateAsync(Comment comment)
    {
        comment.Updated = DateTime.Now;

        var affectedRows = await _commentRepo.UpdateAsync(comment);
        return affectedRows;
    }

    public async Task<int> UpdateContentAsync(UpdateCommentContentRequest request)
    {
        var comment = _mapper.Map<Comment>(request);

        comment.Updated = DateTime.Now;
        
        var affectedRows = await _commentRepo.UpdateAsync(comment);
        return affectedRows;
    }

    // GET
    public async Task<GetCommentResponse> GetAsync(int commentId)
    {
        var comment = await _commentRepo.GetAsync(commentId);
        var response = _mapper.Map<GetCommentResponse>(comment);

        return response;
    }
    
    public async Task<List<GetCommentResponse>> GetAllAsync()
    {
        var comments = await _commentRepo.GetAllAsync();
        var responseList = comments
            .Select(comment => _mapper.Map<GetCommentResponse>(comment))
            .OrderByDescending(comment => comment.Created)
            .ToList();

        return responseList;
    }

    public async Task<List<GetCommentResponse>> GetAllByUserIdAsync(int userId)
    {
        var comments = await _commentRepo.GetAllAsync();
        var responseList = comments
            .Where(comment => comment.AuthorId == userId)
            .Select(comment => _mapper.Map<GetCommentResponse>(comment))
            .OrderByDescending(comment => comment.Created)
            .ToList();

        return responseList;
    }

    public async Task<List<GetCommentResponse>> GetAllByPostIdAsync(int postId)
    {
        var comments = await _commentRepo.GetAllAsync();
        var responseList = comments
            .Where(comment => comment.PostId == postId)
            .Select(comment => _mapper.Map<GetCommentResponse>(comment))
            .OrderByDescending(comment => comment.Created)
            .ToList();

        return responseList;
    }

    public async Task<List<GetCommentResponse>> GetChildrenAsync(int commentId)
    {
        var comments = await _commentRepo.GetAllAsync();
        var responseList = comments
            .Where(comment => comment.ParentId == commentId)
            .Select(comment => _mapper.Map<GetCommentResponse>(comment))
            .OrderByDescending(comment => comment.Created)
            .ToList();

        return responseList;
    }

    public async Task<int> GetCountByPostIdAsync(int postId)
    {
        var commentsList = await _commentRepo.GetAllAsync();
        var response = commentsList
            .Count(comment => comment.PostId == postId);

        return response;
    }

    public async Task<int> GetCountByUserIdAsync(int userId)
    {
        var commentsList = await _commentRepo.GetAllAsync();
        var response = commentsList
            .Count(comment => comment.AuthorId == userId);

        return response;
    }

    public async Task<int> ReactAsync(ReactionCommentRequest request)
    {
        var userCommentReaction = _mapper.Map<UsersCommentReactions>(request);
        var affectedRows = await _usersCommentReactionsRepo.AddAsync(userCommentReaction);
        
        return affectedRows;
    }

    public async Task<bool> IsExistAsync(int commentId) =>
        await _commentRepo.IsExist(commentId);

    // DELETE

    public async Task<int> DeleteAsync(int commentId)
    {
        int affectedRows = await _usersCommentReactionsRepo.DeleteReactsByCommentIdAsync(commentId);
        affectedRows += await _commentRepo.DeleteAsync(commentId);
        
        return affectedRows;
    }

    public async Task<int> DeleteAllByPostIdAsync(int postId)
    {
        var commentsList = await _commentRepo.GetAllAsync();
        int affectedRows = 0;
            
        commentsList.ToList()
            .ForEach(async comment =>
            {
                if (comment.PostId != postId) return;

                affectedRows++;
                await _commentRepo.DeleteAsync(comment.Id);
            });

        return affectedRows;
    }

    public async Task<int> DeleteAllByUserIdAsync(int userId)
    {
        
        var comments = await _commentRepo.GetAllAsync();
        int affectedRows = 0;
            
        comments.ToList()
            .ForEach(async comment =>
            {
                if (comment.AuthorId != userId) return;

                affectedRows++;
                await _commentRepo.DeleteAsync(comment.Id);
            });

        return affectedRows;
    }
}