using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BankManagement.Common
{
    public class BankHelper
    {
        public static Type[] GetTypesNamespace(Assembly assembly = null, string nameSpace = "BankManagement.Models")
        {
            if (assembly == null)
            {
                assembly = Assembly.Load("BankManagement");
            }
            return assembly.GetTypes().
                Where(t => string.Equals(t.Namespace,nameSpace, StringComparison.Ordinal)).ToArray();
        }

       
    }
}
