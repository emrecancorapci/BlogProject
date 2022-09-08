using System.Text;
using BlogProject.Business.MapperProfile;
using BlogProject.Business.Services.AuthenticationService;
using BlogProject.Business.Services.CommentService;
using BlogProject.Business.Services.PostService;
using BlogProject.Business.Services.TagService;
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

var isDevelopment = builder.Environment.IsDevelopment();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors();

// Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        
        var key = builder.Configuration["JsonWebTokenKeys:IssuerSigningKey"];
        var encodedKey = Encoding.UTF8.GetBytes(key);
        var signingKey = new SymmetricSecurityKey(encodedKey);

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

// Swagger
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
builder.Services.AddDbContext<BlogProjectDbContext>(
    optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        optionsBuilder.EnableDetailedErrors(isDevelopment);
        optionsBuilder.EnableSensitiveDataLogging(false);
    });

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
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITagService, TagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// TODO : Add soft delete
// TODO : Configure API routing endpoints
// TODO : Add a key for multiple post edits ( and migrate again )
// TODO : Implement tag and category services and controllers