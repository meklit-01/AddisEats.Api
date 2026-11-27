using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AddisEats.Api.Models;
using AddisEats.Api.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AddisEats.Api.Services.AuthServices;

public class AuthService
{
    private readonly JwtOptions _options;

    public AuthService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }
    public string CreateAccessToken(User user)
    {
        var claims = new[]
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id.ToString()
                ),
            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()
                ),
            new Claim(
                ClaimTypes.Name,
                user.FullName
                ),
            new Claim(
                ClaimTypes.Role,
                user.Role
            ),
             new Claim(
                "IsVerified",
                user.IsVerified ? "true": "false"
            )

        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.SigningKey)
            );
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_options.AccessTokenMinutes),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}