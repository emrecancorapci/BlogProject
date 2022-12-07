using yabp.Business.Services.CategoryService.Dtos;

namespace yabp.Business.Services.CategoryService;

public interface ICategoryService
{
    Task<int> AddAsync(CategoryData request);
    Task<int> UpdateAsync(CategoryData task);
    Task<int> DeleteAsync(int id);
    Task<CategoryData?> GetAsync(int id);
    Task<IList<CategoryData>> GetAllAsync();
    Task<bool> IsExistAsync(int id);
}