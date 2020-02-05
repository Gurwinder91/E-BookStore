using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using EBookStore.Persistence.Models;

namespace EBookStore.Application.Users.Queries.IssueToken
{
    public class UserIssueTokenModel
    {
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
