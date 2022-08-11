using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Relations;

public class EFUsersPostReactionsRepository : IUsersPostReactionsRepository
{
    private readonly BlogProjectDbContext context;

    public EFUsersPostReactionsRepository(BlogProjectDbContext context) =>
        this.context = context;

    public async Task<IList<UsersPostReactions>> GetAllAsync() =>
        await context.UsersPostReactions.ToListAsync();

    public async Task<IList<Post>> GetReactedPostsByUserIdAsync(int userId)
    {
        var posts = new List<Post>();
        var postIds = context.UsersPostReactions
            .Where(pe => pe.UserId == userId)
            .Select(p => p.PostId);

        foreach (var id in postIds)
            posts.Add(await context.Posts.FindAsync(id));

        return posts;
    }

    public async Task<IList<User>> GetReactedUsersByPostIdAsync(int postId)
    {
        var users = new List<User>();
        var userIds = context.UsersPostReactions
            .Where(pe => pe.PostId == postId)
            .Select(p => p.UserId);

        foreach (var id in userIds)
            users.Add(await context.Users.FindAsync(id));

        return users;
    }

    public async Task<int> AddAsync(UsersPostReactions entity)
    {
        await context.UsersPostReactions.AddAsync(entity);
        var affectedRows = await context.SaveChangesAsync();

        return affectedRows;
    }

    public async Task<int> AddAsync(int userId, int postId)
    {
        var entity = new UsersPostReactions { UserId = userId, PostId = postId };
        await context.UsersPostReactions.AddAsync(entity);
        
        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(UsersPostReactions entity)
    {
        context.UsersPostReactions.Remove(entity);
        
        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int userId, int postId)
    {
        var entity = new UsersPostReactions { UserId = userId, PostId = postId }; 
        context.UsersPostReactions.Remove(entity);
        
        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAllPostReactsByUserIdAsync(int userId)
    {
        var usersLikesList = await context.UsersPostReactions
            .Where(usersLikes => usersLikes.UserId == userId)
            .ToListAsync();

        foreach (var usersLikes in usersLikesList)
            context.UsersPostReactions.Remove(usersLikes);

        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }
    

    public async Task<int> DeleteAllPostReactsByPostIdAsync(int postId)
    {
        var usersLikesList = await context.UsersPostReactions
            .Where(usersLikes => usersLikes.PostId == postId)
            .ToListAsync();

        foreach (var usersLikes in usersLikesList)
            context.UsersPostReactions.Remove(usersLikes);

        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }
}