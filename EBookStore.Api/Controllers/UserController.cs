using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using EBookStore.Application.Users.Queries.IssueToken;
using EBookStore.Application.Users.Queries.Orders;
using EBookStore.Application.Users.Queries.VerifyUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<VerifyUserModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TokenAsync(VerifyUserQuery verifyUserQuery)
        {
            var token = await Mediator.Send(verifyUserQuery);
            return Ok(token);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserOrderModel>), (int)HttpStatusCode.OK)]
        [Route("orders")]
        [Authorize]
        public async Task<IActionResult> BookOrdersAsync()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var books = await Mediator.Send(new UserOrderQuery {UserEmail = email });
            return Ok(books);
        }
    }
}