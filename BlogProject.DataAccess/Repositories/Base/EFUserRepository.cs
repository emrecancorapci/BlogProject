using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.DataAccess.Repositories.Base;

public class EFUserRepository : IUserRepository
{
    private readonly BlogProjectDbContext context;

    public EFUserRepository(BlogProjectDbContext context) =>
        this.context = context;

    public async Task<IList<User>> GetAllAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetAsync(int id) =>
        await context.Users.FindAsync(id);

    public async Task<int> Add(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> Update(User user)
    {
        context.Users.Update(user);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        int affected = 0;
        var user = await context.Users
            .FirstOrDefaultAsync(user => user.Id == id);
        if(user != null)
        {
            context.Users.Remove(user);
            affected = await context.SaveChangesAsync();
        }

        return affected;
    }

    public async Task<bool> IsExist(int id)
        => await context.Users.AnyAsync(user => user.Id == id);

    public async Task<User?> ValidateUser(string username)
        => await context.Users.FirstOrDefaultAsync(user => user.Username == username);

    public async Task<bool> IsEmailExist(string email) 
        => await context.Users.AnyAsync(user => user.Email == email);
}