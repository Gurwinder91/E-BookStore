using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.PurchaseBooks.Commands.PurchaseBook
{
    public class PurchaseBookCommand: IRequest
    {
        public int BookId { get; set; }

        public string PaymentMode { get; set; }

        [JsonIgnore]
        public string UserEmail { get; set; }
    }
}
