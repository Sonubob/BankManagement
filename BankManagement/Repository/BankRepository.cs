using BankManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public class BankRepository<T> : IBankRepository<T> where T : class
    {
        private readonly DbContext context;

        private readonly DbSet<T> entities;

        public BankRepository(DbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        public async Task<IQueryable<T>> GetItemsAsync(bool IsActive)
        {

            IQueryable<T> result = await Task.Run(() => entities);
            return result;

            //Where(s => s.GetType().GetProperty("IsActive").GetConstantValue().ToString() == IsActive.ToString())
        }
    }
}
