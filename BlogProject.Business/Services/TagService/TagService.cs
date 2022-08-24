using BlogProject.Business.Services.TagService.Dtos;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.Entities.Base;

namespace BlogProject.Business.Services.TagService;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository) => 
        _tagRepository = tagRepository;

    public async Task<int> AddAsync(TagData data)
    {
        var tag = new Tag { Name = data.Name, Description = data.Description };
        var tagId = await _tagRepository.AddAsync(tag);

        return tagId;
    }

    public async Task<int> UpdateAsync(TagData task)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<TagData?> GetAsync(int id)
    {
        var tag = await _tagRepository.GetAsync(id);
        var response = new TagData { Name = tag.Name, Description = tag.Description };

        return response;
    }

    public async Task<IList<TagData>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsExistAsync(int id) => 
        await _tagRepository.IsExist(id);
}