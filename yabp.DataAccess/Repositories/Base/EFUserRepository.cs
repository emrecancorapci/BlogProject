using yabp.DataAccess.Repositories.Base.Interfaces;
using yabp.Entities.Base;
using Microsoft.EntityFrameworkCore;
using yabp.DataAccess.Data;

namespace yabp.DataAccess.Repositories.Base;

public class EFUserRepository : IUserRepository
{
    private readonly yabpDbContext _context;

    public EFUserRepository(yabpDbContext context) =>
        _context = context;

    public async Task<IList<User>> GetAllAsync() =>
        await _context.Users.ToListAsync();

    public async Task<User?> GetAsync(int id) =>
        await _context.Users.FindAsync(id);

    public async Task<int> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> UpdateAsync(User user)
    {
        _context.Users.Update(user);

        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(user => user.Id == id);

        if (user == null) return 0;
        
        _context.Users.Remove(user);

        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows;
    }

    public async Task<bool> IsExist(int id)
        => await _context.Users.AnyAsync(user => user.Id == id);

    public async Task<User?> ValidateUserAsync(string username)
        => await _context.Users.FirstOrDefaultAsync(user => user.Username == username);

    public async Task<bool> IsEmailExist(string email) 
        => await _context.Users.AnyAsync(user => user.Email == email);
}