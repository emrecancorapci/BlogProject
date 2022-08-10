using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFPostRepository : IPostRepository
{
    private readonly BlogProjectDbContext context;

    public EFPostRepository(BlogProjectDbContext context)
    {
        this.context = context;
    }

    public async Task<IList<Post>> GetAllAsync()
        => await context.Posts.ToListAsync();

    public async Task<Post?> GetAsync(int id)
        => await context.Posts.FindAsync(id);

    public async Task<int> Add(Post entity)
    {
        await context.Posts.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> Update(Post entity)
    {
        context.Posts.Update(entity);
        return await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);

        context.Posts.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> IsExist(int id)
        => await context.Posts.AnyAsync(entity => entity.Id == id);

    public async Task<Tag> GetAllTagsAsync(int id)
        => await context.Tags
            .FirstOrDefaultAsync(entity => entity.Id == id);

    public async Task<Category> GetAllCategoriesAsync(int id)
        => await context.Categories
            .FirstOrDefaultAsync(entity => entity.Id == id);
}