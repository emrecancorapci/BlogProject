using AutoMapper;
using Business.Services.CategoryService.Dtos;
using Business.Services.CommentService.Dtos;
using Business.Services.PostService.Dtos;
using Business.Services.TagService.Dtos;
using Business.Services.UserService.Dtos;
using Entities.Base;

namespace Business.MapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // User
        CreateMap<AddUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<User, UserValidationResponse>();
        CreateMap<User, GetUserResponse>();

        // Category
        CreateMap<Category, CategoryData>();
        CreateMap<CategoryData, Category>();

        // Tag
        CreateMap<Tag, TagData>();
        CreateMap<TagData, Tag>();

        // Comment
        CreateMap<AddCommentRequest, Comment>();
        CreateMap<UpdateCommentContentRequest, Comment>();
        CreateMap<ReactionCommentRequest, Comment>();

        CreateMap<Comment, GetCommentResponse>();

        // Post
        CreateMap<AddPostRequest, Post>();
        CreateMap<ReactionPostRequest, Post>();
        CreateMap<UpdatePostContentRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();

        CreateMap<Post, GetPostResponse>();
    }
}
