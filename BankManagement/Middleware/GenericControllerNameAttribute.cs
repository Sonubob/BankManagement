using BankManagement.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Middleware
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false,Inherited =true)]
    public class GenericControllerNameAttribute: Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if(controller.ControllerType.GetGenericTypeDefinition() == typeof(AccountsController<>))
            {
                var entityType = controller.ControllerType.GenericTypeArguments[0];
                controller.ControllerName = entityType.Name;
                controller.RouteValues["Controller"] = entityType.Name;
            }
        }
    }
}
