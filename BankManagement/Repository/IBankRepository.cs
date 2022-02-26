using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public interface IBankRepository<T>
    {
        public  Task<IQueryable<T>> GetItemsAsync(bool IsActive);
    }
}
