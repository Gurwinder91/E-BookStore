using AutoMapper;
using EBookStore.Application.Exceptions;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.Users.Queries.Orders
{
    public class UserOrderQueryHandler : IRequestHandler<UserOrderQuery, IEnumerable<UserOrderModel>>
    {
        private readonly IPurchasedBookRepository _purchasedBookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserOrderQueryHandler(IPurchasedBookRepository purchasedBookRepository, IUserRepository userRepository, IMapper mapper)
        {
            _purchasedBookRepository = purchasedBookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserOrderModel>> Handle(UserOrderQuery request, CancellationToken cancellationToken)
        {
            var userOrders =  await _purchasedBookRepository.FindAll(user => user.User.Email == request.UserEmail)
                .Include(x => x.Book).ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserOrderModel>>(userOrders);
        }
    }
}
