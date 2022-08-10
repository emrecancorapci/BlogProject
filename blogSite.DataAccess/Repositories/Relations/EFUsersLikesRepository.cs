using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using BlogProject.Entities.Base;
using BlogProject.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Relations;

public class EFUsersLikesRepository : IUsersLikesRepository
{
    private readonly BlogProjectDbContext context;

    public EFUsersLikesRepository(BlogProjectDbContext context)
    {
        this.context = context;
    }
    
    public async Task<IList<UsersLikes>> GetAllAsync()
        => await context.UsersLikes.ToListAsync();

    public async Task<IList<Post>> GetLikesByUserIdAsync(int userId)
    {
        var posts = new List<Post>();
        var postIds = context.UsersLikes
            .Where(pe => pe.UserId == userId).Select(p => p.PostId);

        foreach (var id in postIds)
            posts.Add(await context.Posts.FindAsync(id));

        return posts;
    }

    public async Task<IList<User>> GetUsersByPostIdAsync(int postId)
    {
        var users = new List<User>();
        var userIds = context.UsersLikes
            .Where(pe => pe.PostId == postId).Select(p => p.UserId);

        foreach (var id in userIds)
            users.Add(await context.Users.FindAsync(id));

        return users;
    }

    public async Task<bool> AddAsync(UsersLikes entity)
    {
        var usersLikes = await context.UsersLikes.AddAsync(entity);
        await context.SaveChangesAsync();

        return usersLikes != null;
    }

    public async Task<bool> AddAsync(int userId, int postId)
    {
        var entity = new UsersLikes { UserId = userId, PostId = postId };
        var usersLikes = await context.UsersLikes.AddAsync(entity);
        await context.SaveChangesAsync();

        return usersLikes != null;
    }

    public async Task<bool> DeleteAsync(UsersLikes entity)
    {
        var usersLikes = context.UsersLikes.Remove(entity);
        await context.SaveChangesAsync();
        
        return usersLikes != null;
    }

    public async Task<bool> DeleteAsync(int userId, int postId)
    {
        var entity = new UsersLikes { UserId = userId, PostId = postId };
        var usersLikes = context.UsersLikes.Remove(entity);
        await context.SaveChangesAsync();
        
        return usersLikes != null;
    }

    public async Task<int> DeleteUsersAllAsync(int userId)
    {
        int count = 0;
        
        var usersLikesList = await context.UsersLikes
            .Where(usersLikes => usersLikes.UserId == userId).ToListAsync();

        foreach (var usersLikes in usersLikesList)
        {
            count++;
            context.UsersLikes.Remove(usersLikes);
        }
        
        return count;
    }
    

    public async Task<int> DeletePostAllAsync(int postId)
    {
        int count = 0;
        
        var usersLikesList = await context.UsersLikes
            .Where(usersLikes => usersLikes.PostId == postId).ToListAsync();

        foreach (var usersLikes in usersLikesList)
        {
            count++;
            context.UsersLikes.Remove(usersLikes);
        }

        return count;
    }
}