using EBookStore.Application.Exceptions;
using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.PurchaseBooks.Commands.PurchaseBook
{
    public class PurchaseBookCommandHandler : IRequestHandler<PurchaseBookCommand, Unit>
    {
        private readonly IPurchasedBookRepository _purchasedBookrepository;

        private readonly IUserRepository _userRepository;

        public PurchaseBookCommandHandler(IPurchasedBookRepository purchasedBookrepository, IUserRepository userRepository)
        {
            _purchasedBookrepository = purchasedBookrepository;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(PurchaseBookCommand request, CancellationToken cancellationToken)
        {
            var foundUser = await _userRepository.FindAsync(user => user.Email == request.UserEmail, cancellationToken);
            if (foundUser is null)
            {
                throw new NotFoundException(nameof(User), request.UserEmail);
            }

            var purchaseBook = new PurchasedBook
            {
                BookId = request.BookId,
                UserId = foundUser.Id,
                PaymentMode = request.PaymentMode
            };

            await _purchasedBookrepository.CreateAsync(purchaseBook);

            await _purchasedBookrepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
