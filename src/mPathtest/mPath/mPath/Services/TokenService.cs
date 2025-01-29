namespace mPath.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class TokenService
{
  private readonly string _secret;
  private readonly string _issuer;
  private readonly string _audience;

  public TokenService(string secret, string issuer, string audience)
  {
    _secret = secret;
    _issuer = issuer;
    _audience = audience;
  }

  public string GenerateToken(string userId)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new Claim[]
      {
        new Claim(ClaimTypes.NameIdentifier, userId)
      }),
      Expires = DateTime.UtcNow.AddHours(1),
      Issuer = _issuer,
      Audience = _audience,
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
