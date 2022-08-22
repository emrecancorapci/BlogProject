using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFCommentRepository : ICommentRepository
{
    private readonly BlogProjectDbContext _context;

    public EFCommentRepository(BlogProjectDbContext context) =>
        _context = context;

    public async Task<IList<Comment>> GetAllAsync() => 
        await _context.Comments.ToListAsync();

    public async Task<Comment?> GetAsync(int id) => 
        await _context.Comments.FindAsync(id);

    public async Task<int> AddAsync(Comment entity)
    {
        entity.Created = DateTime.Now;
        entity.Updated = DateTime.Now;

        await _context.Comments.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAsync(Comment entity)
    {
        entity.Updated = DateTime.Now;

        _context.Comments.Update(entity);
        
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Comments
            .FirstOrDefaultAsync(x => x.Id == id);

        if(entity == null) return 0;

        _context.Comments.Remove(entity);
        
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id) 
        => await _context.Comments.AnyAsync(entity => entity.Id == id);
}