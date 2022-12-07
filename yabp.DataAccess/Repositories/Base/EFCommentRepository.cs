using yabp.Entities.Base;
using yabp.DataAccess.Data;
using yabp.DataAccess.Repositories.Base.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace yabp.DataAccess.Repositories.Base;

public class EFCommentRepository : ICommentRepository
{
    private readonly yabpDbContext _context;

    public EFCommentRepository(yabpDbContext context) =>
        _context = context;

    public async Task<IList<Comment>> GetAllAsync() => 
        await _context.Comments.ToListAsync();

    public async Task<Comment?> GetAsync(int id) => 
        await _context.Comments.FindAsync(id);

    public async Task<int> AddAsync(Comment entity)
    {
        await _context.Comments.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAsync(Comment entity)
    {
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