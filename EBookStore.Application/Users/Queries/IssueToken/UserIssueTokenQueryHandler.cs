using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.Users.Queries.IssueToken
{
    public class UserIssueTokenQueryHandler : IRequestHandler<UserIssueTokenQuery, UserIssueTokenModel>
    {
        private readonly IConfiguration _configuration;

        public UserIssueTokenQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserIssueTokenModel> Handle(UserIssueTokenQuery request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppTokenSecret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, request.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserIssueTokenModel
            {
                Token = await Task.Run(() => tokenHandler.WriteToken(token))
            };
        }

      
    }
}
