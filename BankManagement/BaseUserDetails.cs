using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement
{
    public abstract class BaseUserDetails
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }
    }
}
