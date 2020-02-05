using System;
using System.Collections.Generic;
using System.Text;

namespace E_BookStore.Model
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string BookTitle { get; set; }

        public string PublishedOn { get; set; }

        public string Cost { get; set; }
    }
}
