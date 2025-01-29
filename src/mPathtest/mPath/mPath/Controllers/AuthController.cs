using Microsoft.AspNetCore.Mvc;
using mPath.Services;
using Microsoft.Extensions.Options;

namespace mPath.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController : ControllerBase
  {
    Authentication _authentication;

    public AuthController(IOptions<Authentication> appSettings)
    {
      _authentication = appSettings.Value;

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
      if (request.Username is "admin" or "user"
          && request.Password == "password") 
      {
        var tokenHandler = new TokenService
        (_authentication.Key,
          _authentication.Issuer,
          _authentication.Audience);
        var tokenString = tokenHandler.GenerateToken(request.Username);
        return Ok(new { Token = tokenString, User = request.Username });
      }

      return Unauthorized();
    }
  }

  public class LoginRequest
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
