using AutoMapper;
using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.MapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserValidationResponse>();

        CreateMap<AddCommentRequest, Comment>();
        CreateMap<UpdateCommentContentRequest, Comment>();

        // Post
        CreateMap<AddPostRequest, Post>();
        CreateMap<UpdatePostContentRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();

        CreateMap<Post, GetPostResponse>();

        }
}
