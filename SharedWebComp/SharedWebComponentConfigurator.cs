﻿using System.Web.Hosting;
using System.Web.Mvc;

namespace SharedWebComponents {
    public class SharedWebComponentConfigurator {
        public static void Configure() {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
            HostingEnvironment.RegisterVirtualPathProvider(new SVirtualPathProvider());
        }
    }
}