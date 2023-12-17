using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace xFood.Infrastructure
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public SymmetricSecurityKey JwtSecurityKey => new(Encoding.UTF8.GetBytes(Secret));
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpiryInDays { get; set; }
    }
}