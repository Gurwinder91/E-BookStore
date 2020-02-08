using AutoMapper;
using EBookStore.Application.Exceptions;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.Books.Queries.GetSpecificBook
{
    public class GetSpecificBookQueryHandler : IRequestHandler<GetSpecificBookQuery, GetSpecificBookViewModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetSpecificBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetSpecificBookViewModel> Handle(GetSpecificBookQuery request, CancellationToken cancellationToken)
        {
            var foundBook = await _bookRepository.FindAsync(book => book.Id == request.bookId, cancellationToken);
            if(foundBook is null)
            {
                throw new NotFoundException(nameof(Book), request.bookId);
            }

            return _mapper.Map<GetSpecificBookViewModel>(foundBook);
        }
    }
}
