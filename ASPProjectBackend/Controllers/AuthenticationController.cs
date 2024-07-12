﻿using ASPProjectBackend.Data;
using ASPProjectBackend.Models;
using ASPProjectBackend.Models.DTO;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPProjectBackend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ApplicationDbContext context) : ControllerBase
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly ApplicationDbContext _context = context;
    private readonly string _issuer = configuration["Jwt:Issuer"];
    private readonly string _audience = configuration["Jwt:Audience"];
    private readonly string _jwtkey = configuration["Jwt:Key"];
    private readonly string _clientId = configuration["Google:ClientId"];

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginModel model)
    {
        bool newUser = false;
        var payload = await VerifyGoogleToken(model.IdToken);
        if (payload == null)
        {
            return Unauthorized();
        }

        var user = await _userManager.FindByEmailAsync(payload.Email);
        if (user == null)
        {
            newUser = true;
            user = new User
            {
                UserName = payload.Name,
                Email = payload.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
        }

        var token = GenerateJwtToken(user.UserName, user.Email);

        return Ok(new AuthResponse
        {
            Token = token,
            NewUser = newUser
        });
    }

    private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = [_clientId]
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            return payload;
        }
        catch
        {
            return null;
        }
    }
    private string GenerateJwtToken(string userName, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtkey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, userName),
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
