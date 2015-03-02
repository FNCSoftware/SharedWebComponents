using System.Web.Mvc;
using SharedWebComponents.Models;

namespace SharedWebComponents.Controllers {
    public class TestController : Controller{
        public ActionResult Index() {
            var viewModel = new TestViewModel("Hello");
            return PartialView("Test", viewModel);
        }
    }
}