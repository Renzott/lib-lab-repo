using creditos_backend.Authetication.Interfaces;
using creditos_backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace creditos_backend.Authetication
{
    public class JWTUserLogin : IJWTUserLogin
    {
        private readonly IConfiguration _config;

        public JWTUserLogin(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJSONWebToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Name),
                new Claim(JwtRegisteredClaimNames.Sub,user.LastName),
                new Claim(JwtRegisteredClaimNames.Sub,user.Mail),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials
                );

            var tokenEncode = new JwtSecurityTokenHandler().WriteToken(token);

           return tokenEncode;
        }
    }
}
