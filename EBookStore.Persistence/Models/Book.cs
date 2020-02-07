using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Models
{
    public class Book: Entity
    {
        public Book()
        {
            PurchasedBooks = new HashSet<PurchasedBook>();
        }
        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public DateTime PublishedOn { get; set; }

        public decimal Cost { get; set; }

        public int Stock { get; set; }

        public ICollection<PurchasedBook> PurchasedBooks { get; private set; }
    }
}
