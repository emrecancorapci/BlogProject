using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Business.Services.AuthenticationService;
using Business.MapperProfile;
using Microsoft.EntityFrameworkCore;
using Business.Services.CategoryService;
using DataAccess.Data;
using Business.Services.CommentService;
using Business.Services.PostService;
using Business.Services.TagService;
using Business.Services.UserService;
using DataAccess.Repositories.Base.Interfaces;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Relations.Interfaces;
using DataAccess.Repositories.Relations;
using API;

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
        if (key == null) throw new ArgumentNullException(nameof(key));

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
    optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseNpgsql(connectionString)
            .EnableDetailedErrors(false)
            .EnableSensitiveDataLogging(false);
    });

builder = Middlewares.AddServices(builder);


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
