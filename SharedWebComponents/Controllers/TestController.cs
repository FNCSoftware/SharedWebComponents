using System.Web.Mvc;
using SharedWebComponents.Models;

namespace SharedWebComponents.Controllers {
    public class TestController : Controller {
        [HttpGet]
        public virtual ActionResult Index() {
            var viewModel = new TestViewModel("Hello from shared project");
            return PartialView("Test", viewModel);
        }

        [HttpPost]
        public ActionResult GetJsonResult(string input) {
            return Json(new { input = input });
        }
    }
}