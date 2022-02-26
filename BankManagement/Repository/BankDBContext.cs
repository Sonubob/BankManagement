using BankManagement.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Repository
{
    public class BankDBContext : DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitymethod = typeof(ModelBuilder).GetMethods().FirstOrDefault(x => x.Name == "Entity");
            foreach(Type item in BankHelper.GetTypesNamespace())
            {
                entitymethod?.MakeGenericMethod(item).Invoke(modelBuilder, Array.Empty<object>());

            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
