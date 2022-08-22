using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFPostRepository : IPostRepository
{
    private readonly BlogProjectDbContext context;

    public EFPostRepository(BlogProjectDbContext context) => 
        this.context = context;

    public async Task<IList<Post>> GetAllAsync() =>
        await context.Posts.ToListAsync();

    public async Task<Post?> GetAsync(int id) =>
        await context.Posts.FindAsync(id);

    public async Task<int> AddAsync(Post entity)
    {
        await context.Posts.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAsync(Post entity)
    {
        context.Posts.Update(entity);

        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await context.Posts
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null) return 0;

        context.Posts.Remove(entity);

        int affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id)
        => await context.Posts.AnyAsync(entity => entity.Id == id);
}