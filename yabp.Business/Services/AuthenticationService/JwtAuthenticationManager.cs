using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using yabp.DataAccess.Repositories.Base.Interfaces;
using yabp.Entities.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace yabp.Business.Services.AuthenticationService;

public class JwtAuthenticationManager : IJwtAuthenticationManager
{
    private readonly IUserRepository _userRepository;
    private readonly string _jwtTokenSecret;
    private readonly string _jwtTokenSubject;

    public JwtAuthenticationManager(
        IConfiguration configuration,
        IUserRepository userRepository)
    {
        _jwtTokenSecret = configuration["JsonWebTokenKeys:IssuerSigningKey"];
        _jwtTokenSubject = configuration["JsonWebTokenKeys:Subject"];
        _userRepository = userRepository;
    }

    public async Task<string?> GetJwtTokenAsync(string username)
    {
        var user = await _userRepository.ValidateUserAsync(username);
        if(user == null) return null;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var expireTime = DateTime.UtcNow.AddDays(1);

        var token = new JwtSecurityToken(
            claims : GetClaim(user),
            expires : new DateTimeOffset(expireTime).DateTime,
            signingCredentials : credentials);

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtString = tokenHandler.WriteToken(token);

        return jwtString;
    }

    private IEnumerable<Claim> GetClaim(User user)
    {
        // Subject (Sub) : Subject of the JWT
        // JWT ID (Jti) : Unique identifier; can be used to prevent the JWT from being replayed
        // Issued at Time (Iat) : Time at which the JWT was issued; can be used to determine age of the JWT

        return new Claim[] 
        {
            new Claim(JwtRegisteredClaimNames.Sub, _jwtTokenSubject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.Username),
            new Claim("Email", user.Email),
            new Claim("Role", user.Role)
        };
    }

    //public int? ValidateToken(string token)
    //{   
    //    if (token == "") return null;
        
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));

    //    var parameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = _configuration["JsonWebTokenKeys:ValidateIssuerSigningKey"] == "true",
    //        IssuerSigningKey = key,
    //        ValidateIssuer = _configuration["JsonWebTokenKeys:ValidateIssuer"] == "true",
    //        ValidateAudience = _configuration["JsonWebTokenKeys:ValidateAudience"] == "true",
    //        ClockSkew = TimeSpan.Zero
    //    };

    //    tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);

    //    var jwtToken = (JwtSecurityToken)validatedToken;
    //    var value = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;

    //    if (value == null) return null;

    //    var userId = int.Parse(value);
    //    return userId;
    //}
}