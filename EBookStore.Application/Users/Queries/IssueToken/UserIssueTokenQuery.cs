using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Users.Queries.IssueToken
{
    public class UserIssueTokenQuery : IRequest<UserIssueTokenModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
