using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Books.Queries.GetBookList
{
    public class BookListQuery: IRequest<IEnumerable<BookListViewModel>>
    {

    }
}
