﻿using System.Web;
using System.Web.Mvc;

namespace Toci.Driver.Ui.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
