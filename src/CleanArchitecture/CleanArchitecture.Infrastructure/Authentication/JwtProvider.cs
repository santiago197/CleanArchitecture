﻿
using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public Task<string> Generate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!.Value)
            };
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey!)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddMinutes(480),
                signingCredentials
            );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult<string>(tokenValue);
        }
    }
}
