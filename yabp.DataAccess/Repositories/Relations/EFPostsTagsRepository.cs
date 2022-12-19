using yabp.DataAccess.Repositories.Relations.Interfaces;
using yabp.Entities.Base;
using yabp.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using yabp.DataAccess.Data;

namespace yabp.DataAccess.Repositories.Relations;

public class EFPostsTagsRepository : IPostsTagsRepository
{
    private readonly yabpDbContext context;

    public EFPostsTagsRepository(yabpDbContext context) =>
        this.context = context;

    public async Task<IList<PostsTags>> GetAllAsync() =>
        await context.PostsTags.ToListAsync();

    public async Task<IList<Post>> GetPostsByTagIdAsync(int tagId)
    {
        var posts = new List<Post>();
        var postIds = context.PostsTags
            .Where(pt => pt.TagId == tagId)
            .Select(p => p.PostId);

        foreach (var id in postIds)
            posts.Add(await context.Posts.FindAsync(id));

        return posts;
    }

    public async Task<IList<Tag>> GetTagsByPostIdAsync(int postId)
    {
        var tags = new List<Tag>();
        var tagIds = context.PostsTags
            .Where(pe => pe.PostId == postId).Select(p => p.TagId);

        foreach (var id in tagIds)
            tags.Add(await context.Tags.FindAsync(id));

        return tags;
    }

    public async Task<bool> AddAsync(PostsTags entity)
    {
        var postsTags = await context.PostsTags.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsTags != null;
    }

    public async Task<bool> AddAsync(int tagId, int postId)
    {
        var entity = new PostsTags { TagId = tagId, PostId = postId };
        var postsTags = await context.PostsTags.AddAsync(entity);
        await context.SaveChangesAsync();

        return postsTags != null;
    }

    public async Task<bool> DeleteAsync(PostsTags entity)
    {
        var postsTags = context.PostsTags.Remove(entity);
        await context.SaveChangesAsync();

        return postsTags != null;
    }

    public async Task<bool> DeleteAsync(int tagId, int postId)
    {
        var entity = new PostsTags { TagId = tagId, PostId = postId };
        var postsTags = context.PostsTags.Remove(entity);
        await context.SaveChangesAsync();

        return postsTags != null;
    }

    public async Task<int> DeleteTagAllAsync(int tagId)
    {
        int count = 0;
        
        var postsTagsList = await context.PostsTags
            .Where(postsTags => postsTags.TagId == tagId).ToListAsync();

        foreach (var postsTags in postsTagsList)
        {
            count++;
            context.PostsTags.Remove(postsTags);
        }

        return count;
    }

    public async Task<int> DeletePostAllAsync(int postId)
    {
        int count = 0;
        
        var postsTagsList = await context.PostsTags
            .Where(postsTags => postsTags.PostId == postId).ToListAsync();

        foreach (var postsTags in postsTagsList)
        {
            count++;
            context.PostsTags.Remove(postsTags);
        }

        return count;
    }
}