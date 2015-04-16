﻿namespace Web.Areas.Administration.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Web.Areas.Administration.Controllers;

    public static class AdminMenu
    {
        private static IEnumerable<string> controllers;

        public static IEnumerable<string> Items
        {
            get
            {
                return controllers ?? (controllers = GetControllerNames());
            }
        }

        private static IEnumerable<string> GetControllerNames()
        {
            return
                Assembly.GetCallingAssembly()
                    .GetTypes()
                    .Where(type => type.IsSubclassOf(typeof(AdminController)) && !type.IsAbstract)
                    .ToList()
                    .Select(c => c.Name.Replace("Controller", string.Empty));
        }
    }
}