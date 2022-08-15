using AutoMapper;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Extensions;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.PostService;

public class PostService : IPostService
{
    private readonly IPostRepository postRepository;
    private readonly IPostsEditorsRepository postsEditorsRepository;
    private readonly IPostsTagsRepository postsTagsRepository;
    private readonly IUsersPostReactionsRepository _usersPostReactionsRepository;
    private readonly IMapper mapper;
    
    public PostService(IPostRepository postRepository,
        IPostsEditorsRepository postsEditorsRepository,
        IPostsTagsRepository postsTagsRepository,
        IUsersPostReactionsRepository usersPostReactionsRepository,
        IMapper mapper)
    {
        this.postRepository = postRepository;
        this.postsEditorsRepository = postsEditorsRepository;
        this.postsTagsRepository = postsTagsRepository;
        this._usersPostReactionsRepository = usersPostReactionsRepository;
        this.mapper = mapper;
    }
    
    /// <summary>
    /// Creates new blog post and adds it to the database.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Id of the Created Blog Post</returns>
    public async Task<int> AddPost(AddPostRequest request)
    {
        var post = mapper.Map<Post>(request);

        post.Created = DateTime.Now.SetKindUtc();
        post.Modified = DateTime.Now.SetKindUtc();

        var postId = await postRepository.Add(post);
        return postId;
    }

    public async Task<int> UpdatePost(Post post)
    {
        post.Modified = DateTime.Now.SetKindUtc();
        return await postRepository.Update(post);
    }

    public async Task<int> UpdatePostContent(UpdatePostContentRequest request)
    {
        var post = mapper.Map<Post>(request);

        post.Modified = DateTime.Now.SetKindUtc();
        return await postRepository.Update(post);
    }

    public async Task<int> DeletePost(int id) =>
        await postRepository.DeleteAsync(id);

    public async Task<bool> IsExist(int postId) =>
        await postRepository.IsExist(postId);


    public async Task<GetPostResponse?> GetPostById(int id)
    {
        var post = await postRepository.GetAsync(id);
        var response = mapper.Map<GetPostResponse>(post);
        return response;
    }

    public async Task<IList<GetPostResponse>> GetPostsAsync()
    {
        var posts = await postRepository.GetAllAsync();
        var responses = posts
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetPostsByTagId(int tagId)
    {
        var posts = await postsTagsRepository.GetPostsByTagIdAsync(tagId);
        var responses = posts
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetPostsByUserId(int userId)
    {
        var posts = await postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.AuthorId == userId)
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(x => x.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetPostsByCategoryId(int categoryId)
    {
        var posts = await postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.CategoryId == categoryId)
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(response => response.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetPostsByEditorId(int editorId)
    {
        var posts = await postsEditorsRepository.GetPostsByEditorIdAsync(editorId);
        var responses = posts
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(response => response.Created)
            .ToList();
        
        return responses;
    }

    public async Task<IList<GetPostResponse>> GetPostsBySearch(string search)
    {
        var posts = await postRepository.GetAllAsync();
        var responses = posts
            .Where(post => post.Title.Contains(search) || post.Content.Contains(search))
            .Select(post => mapper.Map<GetPostResponse>(post))
            .OrderBy(response => response.Created)
            .ToList();
        
        return responses;
    }

    public Task<int> ReactionPost(ReactionPostRequest request)
    {
        throw new NotImplementedException();
    }


    public async Task<bool> AddPostEditor(int postId, int editorId) => 
        await postsEditorsRepository.AddAsync(editorId, postId);

    public async Task<bool> DeletePostEditor(int postId, int editorId) => 
        await postsEditorsRepository.DeleteAsync(editorId, postId);

    public async Task<int> DeletePostEditorAll(int editorId) => 
        await postsEditorsRepository.DeleteEditorAllAsync(editorId);
}