using BankManagement.Middleware;
using BankManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace BankManagement.Controllers
{
    [GenericControllerName]
    [Route("api/[controller]")]
    public class AccountsController<T> : Controller where T : BaseUserDetails
    {
        public void Get()
        {
           
        }
    }
}
