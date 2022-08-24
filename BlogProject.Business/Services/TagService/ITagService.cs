using BlogProject.Business.Services.TagService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.TagService;

public interface ITagService
{
    Task<int> AddAsync(TagData data);
    Task<int> UpdateAsync(TagData task);
    Task<int> DeleteAsync(int id);
    Task<TagData?> GetAsync(int id);
    Task<IList<TagData>> GetAllAsync();
    Task<bool> IsExistAsync(int id);
}