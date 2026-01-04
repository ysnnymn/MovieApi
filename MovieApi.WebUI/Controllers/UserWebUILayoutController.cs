using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class UserWebUILayoutController : Controller
    {
        // GET: UserWebUILayoutController
        public ActionResult LayoutUI()
        {
            return View();
        }

    }
}
