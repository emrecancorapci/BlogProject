using BlogProject.Entities;
using BlogProject.Entities.Base;

namespace BlogProject.DataAccess.Repositories;

public interface IRepository<T> where T : class, IEntity, new()
{
    Task<IList<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<bool> IsExist(int id);
}