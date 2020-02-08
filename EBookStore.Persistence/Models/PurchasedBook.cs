using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Models
{
    public class PurchasedBook: Entity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public DateTime PurchasedOn { get; set; }

        public string PaymentMode { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
