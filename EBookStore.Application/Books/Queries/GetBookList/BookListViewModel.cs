using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Books.Queries.GetBookList
{
    public class BookListViewModel
    {
        public string Name { get; set; }

        public string AuthorName { get; set; }

        public decimal Cost { get; set; }

        public int Id { get; set; }
    }
}
