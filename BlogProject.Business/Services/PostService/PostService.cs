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

    public async Task DeletePost(int id) =>
        await postRepository.DeleteAsync(id);

    public async Task<bool> IsExist(int postId) =>
        await postRepository.IsExist(postId);


    public async Task<Post?> GetPostById(int id) =>
        await postRepository.GetAsync(id);

    public async Task<IList<Post>> GetPostsAsync()
    {
        var posts = await postRepository.GetAllAsync();
        return posts
            .OrderBy(x => x.Created)
            .ToList();
    }

    public async Task<IList<Post>> GetPostsByTagId(int tagId)
    {
        var posts = await postsTagsRepository.GetPostsByTagIdAsync(tagId);
        return posts
            .OrderBy(x => x.Created)
            .ToList();
    }

    public async Task<IList<Post>> GetPostsByUserId(int userId)
    {
        var posts = await postRepository.GetAllAsync();
        return posts
            .Where(x => x.AuthorId == userId)
            .OrderBy(x => x.Created)
            .ToList();
    }

    public async Task<IList<Post>> GetPostsByCategoryId(int categoryId)
    {
        var posts = await postRepository.GetAllAsync();
        return posts
            .Where(x => x.CategoryId == categoryId)
            .OrderBy(x => x.Created)
            .ToList();
    }

    public async Task<IList<Post>> GetPostsByEditorIdAsync(int editorId)
    {
        var posts = await postsEditorsRepository.GetPostsByEditorIdAsync(editorId);
        return posts
            .OrderBy(x => x.Created)
            .ToList();
    }

    public async Task<IList<Post>> GetPostsBySearch(string search)
    {
        var posts = await postRepository.GetAllAsync();
        return posts
            .Where(x => x.Title.Contains(search) || x.Content.Contains(search))
            .OrderBy(x => x.Created)
            .ToList();
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