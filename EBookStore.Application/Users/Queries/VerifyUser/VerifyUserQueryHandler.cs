using EBookStore.Application.Exceptions;
using EBookStore.Application.Users.Queries.IssueToken;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.Users.Queries.VerifyUser
{
    public class VerifyUserQueryHandler : IRequestHandler<VerifyUserQuery, VerifyUserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public VerifyUserQueryHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<VerifyUserModel> Handle(VerifyUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(usr => usr.Email == request.Email && usr.Password == request.Password, cancellationToken);
            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            var issuedToken = await _mediator.Send(new UserIssueTokenQuery { Email = request.Email });

            return new VerifyUserModel
            {
                Email = user.Email,
                Token = issuedToken.Token
            };
        }
    }
}
