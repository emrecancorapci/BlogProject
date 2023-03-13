using Business.Services.CategoryService;
using Business.Services.CommentService;
using Business.Services.PostService;
using Business.Services.TagService;
using Business.Services.UserService;
using DataAccess.Repositories.Base.Interfaces;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Relations.Interfaces;
using DataAccess.Repositories.Relations;

namespace API;

public class Middlewares
{
    public static WebApplicationBuilder AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPostRepository, EFPostRepository>();
        builder.Services.AddScoped<ICommentRepository, EFCommentRepository>();
        builder.Services.AddScoped<IUserRepository, EFUserRepository>();
        builder.Services.AddScoped<ITagRepository, EFTagRepository>();
        builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

        builder.Services.AddScoped<IPostsEditorsRepository, EFPostsEditorsRepository>();
        builder.Services.AddScoped<IPostsTagsRepository, EFPostsTagsRepository>();
        builder.Services.AddScoped<IUsersCommentReactionsRepository, EFUsersCommentReactionsRepository>();
        builder.Services.AddScoped<IUsersPostReactionsRepository, EFUsersPostReactionsRepository>();

        // Services
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<ITagService, TagService>();
        builder.Services.AddScoped<ITagService, TagService>();

        return builder;
    }

}