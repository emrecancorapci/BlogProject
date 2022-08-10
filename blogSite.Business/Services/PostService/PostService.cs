using AutoMapper;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.PostService;

public class PostService : IPostService
{
    private readonly IPostRepository postRepository;
    private readonly IPostsEditorsRepository postsEditorsRepository;
    private readonly IPostsTagsRepository postsTagsRepository;
    private readonly IUsersLikesRepository usersLikesRepository;
    private readonly IMapper mapper;
    
    public PostService(IPostRepository postRepository,
        IPostsEditorsRepository postsEditorsRepository,
        IPostsTagsRepository postsTagsRepository,
        IUsersLikesRepository usersLikesRepository,
        IMapper mapper)
    {
        this.postRepository = postRepository;
        this.postsEditorsRepository = postsEditorsRepository;
        this.postsTagsRepository = postsTagsRepository;
        this.usersLikesRepository = usersLikesRepository;
        this.mapper = mapper;
    }
    
    public async Task<int> AddPost(AddPostRequest request)
    {
        var post = mapper.Map<Post>(request);

        post.Created = DateTime.Now;
        post.Modified = DateTime.Now;

        var postId = await postRepository.Add(post);
        return postId;
    }

    public async Task<int> UpdatePost(Post post)
    {
        post.Modified = DateTime.Now;
        return await postRepository.Update(post);
    }

    public async Task<int> UpdatePostContent(UpdatePostContentRequest request)
    {
        var post = mapper.Map<Post>(request);

        post.Modified = DateTime.Now;
        return await postRepository.Update(post);
    }

    public async Task DeletePost(int id) =>
        await postRepository.DeleteAsync(id);

    public async Task<bool> IsExist(int postId) =>
        await postRepository.IsExist(postId);

    public async Task<Post?> GetPostById(int id) =>
        await postRepository.GetAsync(id);

    public async Task<IList<Post>> GetPostsAsync() =>
        await postRepository.GetAllAsync();

    public async Task<IList<Post>> GetPostsByUserId(int userId)
    {
        var posts = await postRepository.GetAllAsync();
        return posts.Where(x => x.AuthorId == userId).ToList();
    }
    
    public async Task<IList<Post>> GetPostsByTagId(int tagId)
    {
        return await postsTagsRepository.GetPostsByTagIdAsync(tagId);
    }

    public async Task<IList<Post>> GetPostsByCategoryId(int categoryId)
    {
        var posts = await postRepository.GetAllAsync();
        return posts.Where(x => x.CategoryId == categoryId).ToList();
    }

    public async Task<IList<Post>> GetPostsBySearch(string search)
    {
        var posts = await postRepository.GetAllAsync();
        return posts.Where(x => x.Title.Contains(search) || x.Content.Contains(search)).ToList();
    }

    public async Task<bool> AddPostEditor(int postId, int editorId)
    {
        return await postsEditorsRepository.AddAsync(editorId, postId);
    }

    public async Task<bool> DeletePostEditor(int postId, int editorId)
    {
        return await postsEditorsRepository.DeleteAsync(editorId, postId);
    }

    public async Task<int> DeletePostEditorAll(int editorId)
    {
        return await postsEditorsRepository.DeleteEditorAllAsync(editorId);
    }


    public async Task<IList<Post>> GetPostsByEditorIdAsync(int editorId)
    {
        return (await postsEditorsRepository.GetPostsByEditorIdAsync(editorId))
            .OrderBy(x => x.Created).ToList();
    }
}