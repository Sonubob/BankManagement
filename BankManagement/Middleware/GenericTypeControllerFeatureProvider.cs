using BankManagement.Common;
using BankManagement.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BankManagement.Middleware
{
    public class GenericTypeControllerFeatureProvider: IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach(Type item in BankHelper.GetTypesNamespace(Assembly.Load("BankManagement"), "BankManagement.Models"))
            {
                var entityType = item;
                var typeName = entityType.Name + "Controller";
                if(!feature.Controllers.Any(t=>t.Name == typeName))
                {
                    var controllerType = typeof(AccountsController<>)
                        .MakeGenericType(entityType)
                        .GetTypeInfo();

                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
   
}
