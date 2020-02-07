using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using EBookStore.Application.PurchaseBooks.Commands.PurchaseBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PurchaseBookController : BaseController
    {
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPost]
        public async Task<IActionResult> BuyBookAsync(PurchaseBookCommand command)
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            command.UserEmail = email;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}