using Microsoft.IdentityModel.Tokens;
using NET5.JWT.CustomUser.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NET5.JWT.CustomUser.Services
{
    public static class TokenService
    {
        private const double EXPIRE_HOURS = 1.0;
        public static string CreateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("9d8534b48w951b9287d492b256");
            var tokenHandler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                });

            foreach(var usrRole in user.UserRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, usrRole.Role.Description));
            }

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
