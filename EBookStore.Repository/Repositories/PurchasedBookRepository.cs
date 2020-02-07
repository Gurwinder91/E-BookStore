using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using EBookStore.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Repository.Repositories
{
    public class PurchasedBookRepository : Repository<PurchasedBook>, IPurchasedBookRepository
    {
        public PurchasedBookRepository(EBookStoreDbContext context) : base(context)
        {
        }
    }
}
