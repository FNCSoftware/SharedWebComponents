scenarios:

(partial view should grab data from shared component controller to show that it is fully self-contained)[Test.cshtml]
use layout from shared component project
	1. navigate to /
use partial view from shared component project from another view
	1. navigate to /Test/UsePartialFromSharedComponent
call action from shared component project controller
	1. remove WebApplication1.Controllers.TestController.Index
	2. navigate to /Test
overwrite action from shared component project controller
	1. navigate to /TestOverwrite
use layout from web project along with partial from shared component project
	1. naviate to /TestViewWithWebLayoutAndSharedComponentPartial

behavior:

prefer views from web project
prefer actions from web project

known issues:

1. intellisense does not understand the CustomVirtualPathProvider (see TestOverwriteController)
2. must change Build Action of new views created in shared component project to be "Imbedded Resource"
3. if you want to use a controller with the same name as a controller that exists in the shared component project, you need to extend from the controller with the same name.  This is just to reduce the number of unexpected errors and not a technical barrier.  For example, if you author a shared view that uses a helper provided to your view engine (ie UrlHelper), it will use the executing controller as its context.  In a shared situation, that controller might not be the one you expect or intend, since it depends on the routing used by the web project that consumes it.  We can avoid all of that confusion by just adopting some conventions around controller naming.
	a. make precise controller names from shared component project (really a good rule for all projects)
	b. if you still find that you want to use the same name as an already-defined controller, you should subclass the controller to ensure no routes are compromised
4. there is some magic parsing that probably needs more fleshing out around the model used for shared views (see VirtualFileRazorViewHelper).  Perhaps a restriction on where it can show up rather than parsing the entire view?