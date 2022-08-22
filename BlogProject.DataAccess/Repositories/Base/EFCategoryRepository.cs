using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly BlogProjectDbContext _context;

    public EFCategoryRepository(BlogProjectDbContext context) =>
        _context = context;

    public async Task<IList<Category>> GetAllAsync() =>
        await _context.Categories.ToListAsync();

    public async Task<Category?> GetAsync(int id) => 
        await _context.Categories.FindAsync(id);

    public async Task<int> AddAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAsync(Category entity)
    {
        _context.Categories.Update(entity);

        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == id);

        if(entity == null) return 0;

        _context.Categories.Remove(entity);
        
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id) => 
        await _context.Categories.AnyAsync(Category => Category.Id == id);
}