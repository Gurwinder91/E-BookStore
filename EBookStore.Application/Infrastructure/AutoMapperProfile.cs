using AutoMapper;
using EBookStore.Application.Books.Queries.GetBookList;
using EBookStore.Application.Books.Queries.GetSpecificBook;
using EBookStore.Application.Users.Queries.Orders;
using EBookStore.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookListViewModel>();

            CreateMap<Book, GetSpecificBookViewModel>();

            CreateMap<PurchasedBook, UserOrderModel>()
                  .ForMember(d => d.WrittenIn, opt => opt.MapFrom(s => s.Book.WrittenIn))
                 .ForMember(d => d.BookName, opt => opt.MapFrom(s => s.Book.Name))
                 .ForMember(d => d.BookAuthor, opt => opt.MapFrom(s => s.Book.AuthorName));
        }
    }
}
