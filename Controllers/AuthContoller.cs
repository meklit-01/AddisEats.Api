
using AddisEats.Api.Services.UserServices;
using AddisEats.Api.Services.AuthServices;
using AddisEats.Api.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly DemoUserService _demoUserService;
    private readonly IPasswordHasher<User> _hasher;
    private readonly AuthService _authService;

    public AuthController(
        DemoUserService demoUserService,
        IPasswordHasher<User> hasher,
        AuthService authService)
    {
        _demoUserService = demoUserService;
        _hasher = hasher;
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<LoginResponseDTO> Login(LoginDTO request)
    {
        var user = _demoUserService.FindByPhone(request.Phone);

        if (user is null)
        {
            return Unauthorized(new
            {
                message = "Invalid phone number."
            });
        }

        var result = _hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password
        );

        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new
            {
                message = "Invalid password."
            });
        }

        var accessToken = _authService.CreateAccessToken(user);

        var response = new LoginResponseDTO
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            ExpiresAtUtc = DateTime.UtcNow.AddMinutes(15)
        };

        return Ok(response);
    }
}
