using System.Web.Mvc;

namespace FMS.Controllers.FMS_Controller
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserID"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login");
            }

        }
    }
}