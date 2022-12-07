using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using yabp.Business.Services.AuthenticationService;
using yabp.Business.MapperProfile;
using Microsoft.EntityFrameworkCore;
using yabp.DataAccess.Data;
using yabp.Business.Services.CommentService;
using yabp.Business.Services.PostService;
using yabp.Business.Services.TagService;
using yabp.Business.Services.UserService;
using yabp.DataAccess.Repositories.Base.Interfaces;
using yabp.DataAccess.Repositories.Base;
using yabp.DataAccess.Repositories.Relations.Interfaces;
using yabp.DataAccess.Repositories.Relations;

var builder = WebApplication.CreateBuilder(args);

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
        if(key == null) throw new ArgumentNullException(nameof(key));

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

builder.Services.AddEndpointsApiExplorer();

// Swagger authorization
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

// Auto Mapper
builder.Services.AddAutoMapper(typeof(MapProfile));

// PostgreSQL Database
builder.Services.AddDbContext<yabpDbContext>(
    optionsBuilder => {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseNpgsql(connectionString)
            .EnableDetailedErrors(false)
            .EnableSensitiveDataLogging(false);
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder =>
    policyBuilder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")); // Web url


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
