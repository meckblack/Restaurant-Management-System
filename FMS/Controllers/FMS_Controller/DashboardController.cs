using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS.Controllers.FMS_Controller
{
    public class DashboardController : BaseController
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }
	}
}