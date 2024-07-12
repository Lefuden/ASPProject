using System.Security.Claims;

namespace ASPProjectFrontend.Repositories;

public interface IJwtTokenValidator
{
    List<Claim> ValidateGoogleToken(string token);
}
