using AutoMapper;
using BlogProject.Business.Services.CategoryService.Dtos;
using BlogProject.Business.Services.CommentService.Dtos;
using BlogProject.Business.Services.PostService.Dtos;
using BlogProject.Business.Services.TagService.Dtos;
using BlogProject.Business.Services.UserService.Dtos;
using BlogProject.Entities.Base;

namespace BlogProject.Business.MapperProfile;

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
