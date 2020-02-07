using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Users.Queries.VerifyUser
{
    public class VerifyUserQuery : IRequest<VerifyUserModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
