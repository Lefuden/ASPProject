using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASPProjectFrontend.Repositories;

public class JwtTokenValidator(IConfiguration configuration) : IJwtTokenValidator
{
    private readonly string _issuer = configuration["Jwt:Issuer"];
    private readonly string _audience = configuration["Jwt:Audience"];
    private readonly string _jwtkey = configuration["Jwt:Key"];
    public List<Claim> ValidateGoogleToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
        if (jwtToken == null)
        {
            return [];
        }

        return [
            jwtToken.Claims.FirstOrDefault(claim => ClaimTypes.Name == claim.Type),
            //jwtToken.Claims.FirstOrDefault(claim => JwtRegisteredClaimNames.Sub == claim.Type),
            jwtToken.Claims.FirstOrDefault(claim => ClaimTypes.Email == claim.Type),
            new Claim("Token", token)
        ];
    }
}

