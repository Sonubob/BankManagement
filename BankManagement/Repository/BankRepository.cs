using BankManagement.Common;
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
            var predicateCheck = GetPredicate("IsActive", IsActive);

            IQueryable<T> result = (IQueryable<T>)await Task.Run(() => entities.Where(predicateCheck));
            return result;

           
        }

        private  Expression<Func<T, bool>> GetPredicate(string propertyToFilter, object value)
        {
            var className = Expression.Parameter(typeof(T));
            var memberAccess = Expression.PropertyOrField(className, propertyToFilter);
            var propertyType = memberAccess.Type;
            var exprRight = Expression.Constant(value, propertyType);
            var equalExpr = Expression.Equal(memberAccess, exprRight);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(equalExpr, className);
            return lambda;

        }
    }
}
