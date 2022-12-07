using yabp.DataAccess.Repositories.Relations.Interfaces;
using yabp.Entities.Base;
using Microsoft.EntityFrameworkCore;
using yabp.DataAccess.Data;
using yabp.Entities.UniqueRelations;

namespace yabp.DataAccess.Repositories.Relations;

public class EFPostsEditorsRepository : IPostsEditorsRepository
{
    private readonly yabpDbContext context;

    public EFPostsEditorsRepository(yabpDbContext context) 
        => this.context = context;

    public async Task<IList<PostEdits>> GetAllAsync()
        => await context.PostEdits.ToListAsync();

    public async Task<IList<Post>> GetPostsByEditorIdAsync(int userId)
    {
        var posts = new List<Post>();
        var postIds = context.PostEdits
            .Where(pe => pe.EditorId == userId).Select(p => p.PostId);

        foreach (var id in postIds)
            posts.Add(await context.Posts.FindAsync(id));

        return posts;
    }

    public async Task<IList<User>> GetUserByPostIdAsync(int postId)
    {
        var users = new List<User>();
        var userIds = context.PostEdits
            .Where(pe => pe.PostId == postId).Select(p => p.EditorId);

        foreach (var id in userIds)
            users.Add(await context.Users.FindAsync(id));

        return users;
    }

    public async Task<bool> AddAsync(PostEdits entity)
    {
        var postsEditors = await context.PostEdits.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsEditors != null;
    }

    public async Task<bool> AddAsync(int userId, int postId)
    {
        var entity = new PostEdits { EditorId = userId, PostId = postId };
        var postsEditors = await context.PostEdits.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsEditors != null;
    }

    public async Task<bool> DeleteAsync(PostEdits entity)
    {
        var postsEditors = context.PostEdits.Remove(entity);
        await context.SaveChangesAsync();
        
        return postsEditors != null;
    }

    public async Task<bool> DeleteAsync(int userId, int postId)
    {
        var entity = new PostEdits { EditorId = userId, PostId = postId };
        var postsEditors = context.PostEdits.Remove(entity);
        await context.SaveChangesAsync();
        
        return postsEditors != null;
    }

    public async Task<int> DeleteRelationsByEditorIdAsync(int userId)
    {
        int count = 0;
        
        var postsEditors = await context.PostEdits
            .Where(pe => pe.EditorId == userId).ToListAsync();

        foreach (var pe in postsEditors)
        {
            count++;
            context.PostEdits.Remove(pe);
        }

        return count;
    }
    
    public async Task<int> DeleteRelationsByPostId(int postId)
    {
        int count = 0;
        
        var postsEditors = await context.PostEdits
            .Where(pe => pe.PostId == postId).ToListAsync();

        foreach (var pe in postsEditors)
        {
            count++;
            context.PostEdits.Remove(pe);
        }

        return count;
    }
}