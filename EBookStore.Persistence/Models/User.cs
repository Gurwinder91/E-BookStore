using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence.Models
{
    public class User: Entity
    {
        public User()
        {
            PurchasedBooks = new HashSet<PurchasedBook>();
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<PurchasedBook> PurchasedBooks { get; private set; }
    }
}
