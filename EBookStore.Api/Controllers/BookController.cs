using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EBookStore.Application.Books.Queries.GetBookList;
using EBookStore.Application.Books.Queries.GetSpecificBook;
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

        [HttpGet]
        [ProducesResponseType(typeof(GetSpecificBookViewModel), (int)HttpStatusCode.OK)]
        [Route("{bookId}")]
        public async Task<IActionResult> GetAsyncById(int bookId)
        {
            var book = await Mediator.Send(new GetSpecificBookQuery { bookId = bookId});
            return Ok(book);
        }

    }
}