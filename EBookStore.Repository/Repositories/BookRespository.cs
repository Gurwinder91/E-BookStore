using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Repository.Repositories
{
    public class BookRespository : Repository<Book>, IBookRepository
    {
        public BookRespository(EBookStoreDbContext context) : base(context)
        {
        }
    }
}
