using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenServices : ITokenService
    {
        //מפתח אבטחה סימטרי
        public readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration config)
        {
            _key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            
        }
        public string CreateToken(AppUser user)
        {
            var claims=new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor=new SecurityTokenDescriptor{
                Subject=new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(7),
                SigningCredentials=creds
            };
            var TokenHandler=new JwtSecurityTokenHandler();
            var token=TokenHandler.CreateToken(tokenDescriptor);
            return TokenHandler.WriteToken(token);
        }
    }
}