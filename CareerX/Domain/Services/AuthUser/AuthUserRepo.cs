using Domain.Models;
using Domain.Services.AuthUser.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser
{
    public class AuthUserRepo : IAuthUserRepository
    {
        protected readonly CareerxDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthUserRepo(CareerxDbContext context, IConfiguration cong)
        {
            _context = context;
            _configuration = cong;
        }


        public async Task<Domain.Models.AuthUser> AddToAuthUser(Domain.Models.AuthUser authUser)
        {
            authUser.Id = Guid.NewGuid();
            await _context.AuthUsers.AddAsync(authUser);
            return authUser;
        }

        public string? CreateToken(Domain.Models.AuthUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");
            }

            string tokenSecret = _configuration.GetSection("AuthSettings:Token").Value;
            if (string.IsNullOrEmpty(tokenSecret) || tokenSecret.Length < 64)
            {
                throw new InvalidOperationException("Token secret must be at least 64 characters long.");
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}