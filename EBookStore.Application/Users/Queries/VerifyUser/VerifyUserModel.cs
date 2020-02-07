using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Users.Queries.VerifyUser
{
    public class VerifyUserModel
    {
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
