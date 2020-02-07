using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EBookStore.Application.Books.Queries.GetBookList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            var books = await Mediator.Send(new BookListQuery());
            return Ok(books);
        }

    }
}