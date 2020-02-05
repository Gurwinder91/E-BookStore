using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Models
{
    public class PurchasedBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
