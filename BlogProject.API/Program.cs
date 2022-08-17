using BlogProject.Business.MapperProfile;
using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.UserService;
using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Relations;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

// Db Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogProjectDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

// Repositories
builder.Services.AddScoped<IPostRepository, EFPostRepository>();
builder.Services.AddScoped<ICommentRepository, EFCommentRepository>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();

builder.Services.AddScoped<IPostsEditorsRepository, EFPostsEditorsRepository>();
builder.Services.AddScoped<IPostsTagsRepository, EFPostsTagsRepository>();
builder.Services.AddScoped<IUsersCommentReactionsRepository, EFUsersCommentReactionsRepository>();
builder.Services.AddScoped<IUsersPostReactionsRepository, EFUsersPostReactionsRepository>();

// Services
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO : Add soft delete
// TODO : Add authentication and authorization with jwt tokens
// TODO : Add password hashing
// TODO : Add a key for multiple post edits
// TODO LAST : Migrate again for changes in entities