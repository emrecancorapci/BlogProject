using AutoMapper;
using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.MapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserValidationResponse>();
    }
}