using System.Web.Mvc;
using Consumer.Models;

namespace Consumer.Controllers {
    public class TestController : SharedWebComponents.Controllers.TestController {
        [HttpGet]
        public override ActionResult Index() {
            var viewModel = new SharedWebComponents.Models.TestViewModel("Hello from Web Project");
            return PartialView("Test", viewModel);
        }

        [HttpGet]
        public ActionResult UsePartialFromSharedComponent() {
            return View(new TestViewModel("Greetings", "Another Greeting"));
        }

        [HttpGet]
        public ActionResult TestViewWithWebLayoutAndSharedComponentPartial() {
            return View();
        }
    }
}