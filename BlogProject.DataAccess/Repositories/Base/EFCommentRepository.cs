using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFCommentRepository : ICommentRepository
{
    private readonly BlogProjectDbContext context;

    public EFCommentRepository(BlogProjectDbContext context) =>
        this.context = context;

    public async Task<IList<Comment>> GetAllAsync() => 
        await context.Comments.ToListAsync();

    public async Task<Comment?> GetAsync(int id) => 
        await context.Comments.FindAsync(id);

    public async Task<int> Add(Comment entity)
    {
        entity.Created = DateTime.Now;
        entity.Updated = DateTime.Now;

        await context.Comments.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> Update(Comment entity)
    {
        entity.Updated = DateTime.Now;

        context.Comments.Update(entity);
        
        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await context.Comments
            .FirstOrDefaultAsync(x => x.Id == id);

        if(entity == null) return 0;

        context.Comments.Remove(entity);
        
        var affectedRows = await context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id) 
        => await context.Comments.AnyAsync(entity => entity.Id == id);
}