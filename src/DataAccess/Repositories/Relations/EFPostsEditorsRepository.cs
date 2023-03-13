using DataAccess.Repositories.Relations.Interfaces;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Entities.UniqueRelations;

namespace DataAccess.Repositories.Relations;

public class EFPostsEditorsRepository : IPostsEditorsRepository
{
    private readonly yabpDbContext context;

    public EFPostsEditorsRepository(yabpDbContext context) 
        => this.context = context;

    public async Task<IList<PostEdits>> GetAllAsync()
        => await context.PostEdits.ToListAsync();

    public async Task<IList<Post>> GetPostsByEditorIdAsync(int userId)
    { 
        var posts = await context.Posts
            .Where(post => post.Editors
                .Any(postEdits => postEdits.EditorId == userId))
            .ToListAsync();

        //var postsTwo = context.Posts
        //    .Include(post => post.Editors
        //            .Where(postEdits => postEdits.EditorId == userId))
        //    .SelectMany()
        //    .ToListAsync();

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