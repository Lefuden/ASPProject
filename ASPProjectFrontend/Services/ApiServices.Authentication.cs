using ASPProjectFrontend.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ASPProjectFrontend.Services;

public partial class ApiServices
{
    public async Task<(ClaimsPrincipal claims, AuthenticationProperties authProperties, bool newUser)> GoogleAuth(string idToken)
    {
        var response = await _client.PostAsJsonAsync("Authentication/google-login", new { IdToken = idToken });

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

        List<Claim> claims = _jwtValidator.ValidateGoogleToken(result.Token);

        ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        AuthenticationProperties authProperties = new()
        {
            IsPersistent = true
        };

        return (new ClaimsPrincipal(claimsIdentity), authProperties, result.NewUser);
    }
}