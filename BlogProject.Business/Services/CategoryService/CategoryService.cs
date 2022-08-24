using BlogProject.Business.Services.CategoryService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) => 
        _categoryRepository = categoryRepository;

    public async Task<int> AddAsync(CategoryData data)
    {
        var category = new Category
            { Name = data.Name, Description = data.Description };
        var categoryId = await _categoryRepository.AddAsync(category);

        return categoryId;
    }

    public async Task<int> UpdateAsync(CategoryData task)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryData?> GetAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(id);
        var response = new CategoryData
            { Name = category.Name, Description = category.Description };

        return response;
    }

    public async Task<IList<CategoryData>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsExistAsync(int id) => 
        await _categoryRepository.IsExist(id);
}