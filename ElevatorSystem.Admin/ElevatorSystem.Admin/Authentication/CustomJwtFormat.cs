using ElevatorSystem.Admin.Models;
using ElevatorSystem.Admin.Models.AuthModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace ElevatorSystem.Admin.Authentication
{
    public class CustomJwtFormat
    {
        private const string _tokenSecret = "401b09eab3c013d4ca54922b";
        private const string _audience = "nguoitao";
        private const string _issuer = "isser";

        public Credentials CreateToken(string role, ApplicationUser userModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim> { };
            DateTime _expires = DateTime.Now.AddDays(13);
            claims.Add(new Claim(ClaimTypes.Role, role));
            claims.Add(new Claim("Username", userModel.UserName));
            claims.Add(new Claim("Email", userModel.Email));
            claims.Add(new Claim("Id", userModel.Id));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSecret));
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Expires = _expires,
                Audience = _audience,
                IssuedAt = DateTime.UtcNow,
                Issuer = _issuer
            };

            var securityToken = tokenHandler.CreateToken(descriptor);
            var refreshToken = tokenHandler.WriteToken(securityToken);

            var crendentials = new Credentials()
            {
                access_token = refreshToken,
                expires = _expires
            };
            return crendentials;

        }
    }
}