using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JashariDenisLB_295_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        public class UserCredentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class JwtResponse
        {
            public string Token { get; set; }
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User")
            };

            if (username == "Denis")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HierMeinBeliebigerGeheimerSchlüssel"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials user)
        {
            if (user.Username == "Denis" && user.Password == "EldenRing")
            {
                var token = GenerateJwtToken(user.Username);
                return Ok(new JwtResponse { Token = token });
            }

            return Unauthorized();
        }
    }
}

