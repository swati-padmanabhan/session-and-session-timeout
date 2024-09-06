using System.Web.Mvc;

namespace SessionAndSessionTimeout.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult SetSession()
        {
            //set session data
            Session["Message"] = "Hello, Jerry!";
            return RedirectToAction("GetSession");
        }

        //this action retrieves the session variable and displays a message indicating whether it was found
        public ActionResult GetSession()
        {
            var message = Session["Message"];

            if (message != null)
            {
                //set a TempData message indicating the session variable was found
                TempData["Status"] = $"Session Variable Found: {message}";
            }
            else
            {
                TempData["Status"] = "No session variable found.";
            }
            return View();
        }

        public ActionResult ClearSession()
        {
            //remove the session variable "Message" by setting it to null
            Session["Message"] = null;

            return RedirectToAction("GetSession");
        }

    }
}