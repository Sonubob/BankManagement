using BankManagement.Middleware;
using BankManagement.Models;
using BankManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace BankManagement.Controllers
{
    [GenericControllerName]
    [Route("api/[controller]")]
    public class AccountsController<T> : Controller where T : class
    {
        private IBankRepository<T> repository { get; set; }

        public AccountsController(IBankRepository<T> _repository)
        {
            repository = _repository;
        }
        public async Task<IQueryable<T>> Get(bool IsActive = true)
        {
          
            return await repository.GetItemsAsync(IsActive);
        }
    }
}
