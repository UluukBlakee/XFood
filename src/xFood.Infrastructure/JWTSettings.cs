using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFood.Infrastructure
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public SymmetricSecurityKey JwtSecurityKey =>new SymmetricSecurityKey (Encoding.UTF8.GetBytes(Secret));
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpiryInDays { get; set; }
    }
}
