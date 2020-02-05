using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBookStore.Application.Users.Queries.IssueToken;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [Route("token")]
        public async Task<IActionResult> TokenAsync(UserIssueTokenQuery userIssueTokenQuery)
        {
            var token = await Mediator.Send(userIssueTokenQuery);
            return Ok(token);
        }
    }
}