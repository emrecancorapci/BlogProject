﻿using AutoMapper;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Extensions;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;

namespace BlogProject.Business.Services.PostService;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IPostsEditorsRepository _postsEditorsRepository;
    private readonly IPostsTagsRepository _postsTagsRepository;
    private readonly IUsersPostReactionsRepository _usersPostReactionsRepository;
    private readonly IMapper _mapper;
    
    public PostService(IPostRepository postRepository,
        IPostsEditorsRepository postsEditorsRepository,
        IPostsTagsRepository postsTagsRepository,
        IUsersPostReactionsRepository usersPostReactionsRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _postsEditorsRepository = postsEditorsRepository;
        _postsTagsRepository = postsTagsRepository;
        _usersPostReactionsRepository = usersPostReactionsRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates new blog post and adds it to the database.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Id of the Created Blog Post</returns>
    public async Task<int> AddAsync(AddPostRequest request)
    {
        var post = _mapper.Map<Post>(request);

        post.Created = DateTime.Now.SetKindUtc();
        post.Modified = DateTime.Now.SetKindUtc();

        var postId = await _postRepository.Add(post);
        return postId;
    }

    public async Task<int> UpdateAsync(Post post)
    {
        post.Modified = DateTime.Now.SetKindUtc();
        return await _postRepository.Update(post);
    }

    public async Task<int> UpdateContentAsync(UpdatePostContentRequest request)
    {
        var post = _mapper.Map<Post>(request);

        post.Modified = DateTime.Now.SetKindUtc();
        await _postsEditorsRepository.AddAsync(
            new PostsEditors
            {
                EditorId = request.EditorId,
                PostId = request.PostId,
                ModifiedDate = DateTime.Now.SetKindUtc(),
                Summary = request.EditionSummary
            });
        
        return await _postRepository.Update(post);
    }

    public async Task<int> DeleteAsync(int id)
    {
        int affectedRows = 
            await _postRepository.DeleteAsync(id) +
            await _postsEditorsRepository.DeleteRelationsByPostId(id);

        return affectedRows;
    }

    public async Task<bool> IsExistAsync(int postId) =>
        await _postRepository.IsExist(postId);


    public async Task<GetPostResponse?> GetAsync(int id)
    {
        var post = await _postRepository.GetAsync(id);
        var response = _mapper.Map<GetPostResponse>(post);

        return response;
    }

    public async Task<IList<GetPostResponse>> GetAllAsync()
    {
        var posts = await _postRepository.GetAllAsync();
        var responses = posts
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetAllByTagIdAsync(int tagId)
    {
        var posts = await _postsTagsRepository.GetPostsByTagIdAsync(tagId);
        var responses = posts
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetAllByUserIdAsync(int userId)
    {
        var posts = await _postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.AuthorId == userId)
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetAllByCategoryIdAsync(int categoryId)
    {
        var posts = await _postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.CategoryId == categoryId)
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(response => response.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetAllByEditorIdAsync(int editorId)
    {
        var posts = await _postsEditorsRepository.GetPostsByEditorIdAsync(editorId);
        var responses = posts
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(response => response.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetAllBySearchAsync(string search)
    {
        var posts = await _postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.Title.Contains(search) || post.Content.Contains(search))
            .Select(post => _mapper.Map<GetPostResponse>(post))
            .OrderByDescending(response => response.Created)
            .ToList();
        
        return responses;
    }

    public async Task<int> ReactAsync(ReactionPostRequest request)
    {
        var reaction = _mapper.Map<UsersPostReactions>(request);

        return await _usersPostReactionsRepository.AddAsync(reaction);
    }


    public async Task<bool> DeleteEditorRelation(int postId, int editorId) => 
        await _postsEditorsRepository.DeleteAsync(editorId, postId);

    public async Task<int> DeleteRelationByEditorIdAsync(int editorId) => 
        await _postsEditorsRepository.DeleteRelationsByEditorIdAsync(editorId);
}