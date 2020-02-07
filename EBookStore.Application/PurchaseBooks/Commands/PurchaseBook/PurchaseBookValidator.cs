using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.PurchaseBooks.Commands.PurchaseBook
{
    public class PurchaseBookValidator : AbstractValidator<PurchaseBookCommand>
    {
        public PurchaseBookValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
        }
        
    }
}
