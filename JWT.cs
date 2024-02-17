using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JashariDenisLB_295_V2
{
    public class JWT : DbContext
    {
        public class User
        {
            [JsonPropertyName("username")]
            public string Username { get; set; }

            [JsonPropertyName("password")]
            public string Password { get; set; }
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("name", user.Username),
                new Claim("role", "User")
            };

            if (user.Username == "Denis")
            {
                claims.Add(new Claim("role", "Admin"));
            }

            var tokenData = new Dictionary<string, object>
            {
                { "claims", claims },
                { "exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds() }
            };

            var token = JsonSerializer.Serialize(tokenData);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
        }
    }
}

