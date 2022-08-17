using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Relations;

public class EFPostsEditorsRepository : IPostsEditorsRepository
{
    private readonly BlogProjectDbContext context;

    public EFPostsEditorsRepository(BlogProjectDbContext context) 
        => this.context = context;

    public async Task<IList<PostsEditors>> GetAllAsync()
        => await context.PostsEditors.ToListAsync();

    public async Task<IList<Post>> GetPostsByEditorIdAsync(int userId)
    {
        var posts = new List<Post>();
        var postIds = context.PostsEditors
            .Where(pe => pe.EditorId == userId).Select(p => p.PostId);

        foreach (var id in postIds)
            posts.Add(await context.Posts.FindAsync(id));

        return posts;
    }

    public async Task<IList<User>> GetUserByPostIdAsync(int postId)
    {
        var users = new List<User>();
        var userIds = context.PostsEditors
            .Where(pe => pe.PostId == postId).Select(p => p.EditorId);

        foreach (var id in userIds)
            users.Add(await context.Users.FindAsync(id));

        return users;
    }

    public async Task<bool> AddAsync(PostsEditors entity)
    {
        var postsEditors = await context.PostsEditors.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsEditors != null;
    }

    public async Task<bool> AddAsync(int userId, int postId)
    {
        var entity = new PostsEditors { EditorId = userId, PostId = postId };
        var postsEditors = await context.PostsEditors.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsEditors != null;
    }

    public async Task<bool> DeleteAsync(PostsEditors entity)
    {
        var postsEditors = context.PostsEditors.Remove(entity);
        await context.SaveChangesAsync();
        
        return postsEditors != null;
    }

    public async Task<bool> DeleteAsync(int userId, int postId)
    {
        var entity = new PostsEditors { EditorId = userId, PostId = postId };
        var postsEditors = context.PostsEditors.Remove(entity);
        await context.SaveChangesAsync();
        
        return postsEditors != null;
    }

    public async Task<int> DeleteRelationsByEditorIdAsync(int userId)
    {
        int count = 0;
        
        var postsEditors = await context.PostsEditors
            .Where(pe => pe.EditorId == userId).ToListAsync();

        foreach (var pe in postsEditors)
        {
            count++;
            context.PostsEditors.Remove(pe);
        }

        return count;
    }
    
    public async Task<int> DeleteRelationsByPostId(int postId)
    {
        int count = 0;
        
        var postsEditors = await context.PostsEditors
            .Where(pe => pe.PostId == postId).ToListAsync();

        foreach (var pe in postsEditors)
        {
            count++;
            context.PostsEditors.Remove(pe);
        }

        return count;
    }
}