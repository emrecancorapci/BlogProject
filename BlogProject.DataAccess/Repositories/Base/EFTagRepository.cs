using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFTagRepository : ITagRepository
{
    private readonly BlogProjectDbContext _context;

    public EFTagRepository(BlogProjectDbContext context) =>
        _context = context;

    public async Task<IList<Tag>> GetAllAsync() =>
        await _context.Tags.ToListAsync();

    public async Task<Tag?> GetAsync(int id) => 
        await _context.Tags.FindAsync(id);

    public async Task<int> AddAsync(Tag entity)
    {
        await _context.Tags.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAsync(Tag entity)
    {
        _context.Tags.Update(entity);

        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Tags
            .FirstOrDefaultAsync(x => x.Id == id);

        if(entity == null) return 0;

        _context.Tags.Remove(entity);
        
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id) => 
        await _context.Tags.AnyAsync(tag => tag.Id == id);
}
