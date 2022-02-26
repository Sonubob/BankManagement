using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public partial class UserAccount: BaseUserDetails
    {
        public string AccountType { get; set; }

        public int AccountNumber { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
