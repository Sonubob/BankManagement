using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public abstract class BaseUserDetails
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
