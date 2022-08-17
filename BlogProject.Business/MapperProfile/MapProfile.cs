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
        // User
        CreateMap<AddUserRequest, User>();

        CreateMap<User, UserValidationResponse>();
        CreateMap<User, GetUserResponse>();

        // Comment
        CreateMap<AddCommentRequest, Comment>();
        CreateMap<UpdateCommentContentRequest, Comment>();

        CreateMap<Comment, GetCommentResponse>();

        // Post
        CreateMap<AddPostRequest, Post>();
        CreateMap<UpdatePostContentRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();

        CreateMap<Post, GetPostResponse>();

        }
}
