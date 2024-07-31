using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASPProjectFrontend.Repositories;

//validerar att jwt token är korrekt
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
        var claims = new List<Claim>(){
            jwtToken.Claims.FirstOrDefault(claim => ClaimTypes.Name == claim.Type),
            jwtToken.Claims.FirstOrDefault(claim => ClaimTypes.Email == claim.Type),
            jwtToken.Claims.FirstOrDefault(claim => ClaimTypes.NameIdentifier == claim.Type),
            new ("Token", token)
        };

        var roleClaims = jwtToken?.Claims.Where(claim => claim.Type == ClaimTypes.Role).ToList();

        if (roleClaims != null)
        {
            claims.AddRange(roleClaims);
        }

        return claims;
    }
}

