using AutoMapper;
using EBookStore.Application.Books.Queries.GetBookList;
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

            CreateMap<PurchasedBook, UserOrderModel>()
                 .ForMember(d => d.BookTitle, opt => opt.MapFrom(s => s.Book.Title))
                 .ForMember(d => d.BookName, opt => opt.MapFrom(s => s.Book.Name))
                 .ForMember(d => d.BookAuthor, opt => opt.MapFrom(s => s.Book.AuthorName));
        }
    }
}
