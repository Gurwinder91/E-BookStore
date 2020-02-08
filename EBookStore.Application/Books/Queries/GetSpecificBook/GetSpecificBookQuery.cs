using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Books.Queries.GetSpecificBook
{
    public class GetSpecificBookQuery : IRequest<GetSpecificBookViewModel>
    {
        public int bookId { get; set; }
    }
}
