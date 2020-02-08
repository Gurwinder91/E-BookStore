using EBookStore.Application.Books.Queries.GetBookList;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Books.Queries.GetSpecificBook
{
    public class GetSpecificBookViewModel: BookListViewModel
    {
        public string WrittenIn { get; set; }

        public string Description { get; set; }
    }
}
