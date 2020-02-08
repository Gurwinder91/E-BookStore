using System;

namespace EBookStore.Application.Users.Queries.Orders
{
    public class UserOrderModel
    {
        public DateTime PurchasedOn { get; set; }

        public string PaymentMode { get; set; }

        public string BookName { get; set; }

        public string WrittenIn { get; set; }

        public string BookAuthor { get; set; }
    }
}