using AutoMapper;
using EBookStore.Persistence;
using EBookStore.Repository.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBookStore.Application.Books.Queries.GetBookList
{
    public class BookListQueryHandler : IRequestHandler<BookListQuery, IEnumerable<BookListViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookListQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookListViewModel>> Handle(BookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll().ToListAsync(cancellationToken);

            var mappedBooks = _mapper.Map<IEnumerable<BookListViewModel>>(books);

            return mappedBooks;
        }
    }
}
