using BlogProject.Business.Services.CategoryService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.CategoryService;

public interface ICategoryService
{
    Task<int> AddAsync(CategoryData request);
    Task<int> UpdateAsync(CategoryData task);
    Task<int> DeleteAsync(int id);
    Task<CategoryData?> GetAsync(int id);
    Task<IList<CategoryData>> GetAllAsync();
    Task<bool> IsExistAsync(int id);
}