using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public  class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }
        public string AccountType { get; set; }

        public int AccountNumber { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
