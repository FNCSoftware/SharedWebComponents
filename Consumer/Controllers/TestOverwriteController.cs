﻿using System.Web.Mvc;

namespace Consumer.Controllers {
    public class TestOverwriteController : SharedWebComponents.Controllers.TestController {
        [HttpGet]
        public override ActionResult Index() {
            var viewModel = new SharedWebComponents.Models.TestViewModel("Hello from Web Project");
            return PartialView("~/SharedWebComponents/Views/Test/Test.cshtml", viewModel);
        }
    }
}