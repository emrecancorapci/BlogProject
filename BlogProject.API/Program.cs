using System.Text;
using BlogProject.Business.MapperProfile;
using BlogProject.Business.Services.AuthenticationService;
using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.UserService;
using BlogProject.DataAccess.Data;
using BlogProject.DataAccess.Repositories.Base;
using BlogProject.DataAccess.Repositories.Base.Interfaces;
using BlogProject.DataAccess.Repositories.Relations;
using BlogProject.DataAccess.Repositories.Relations.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var tokenKey = Encoding.UTF8.GetBytes(builder.Configuration
    .GetSection("JsonWebTokenKeys:IssuerSigningKey")
    .Value);
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var openApiSecurityScheme = new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    };

    options.AddSecurityDefinition("oauth2", openApiSecurityScheme);
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(typeof(MapProfile));

// Db Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogProjectDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

// Repositories
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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();


builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO : Add soft delete
// TODO : Add a key for multiple post edits
// TODO LAST : Migrate again for changes in entities