using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Users.Queries.Orders
{
    public class UserOrderQuery : IRequest<IEnumerable<UserOrderModel>>
    {
        [JsonIgnore]
        public string UserEmail { get; set; }
    }
}
