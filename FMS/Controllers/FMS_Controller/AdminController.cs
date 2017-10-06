using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class AdminController : Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.admin.ToList());
        }

        
        // GET: /Admin/Register
        public ActionResult Register()
        {
            var admin = new Admin();
            return PartialView("Register", admin);
        }

        // POST: /Admin/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "AdminId,AdminUsername,AdminPassword,AdminComfirmPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admin.Add(admin);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return View();
        }

        //GET: /Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: /Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin user)
        {
            var usr = db.admin.Single(u => u.AdminUsername == user.AdminUsername && u.AdminPassword == user.AdminPassword);
            if (usr != null)
            {
                Session["AdminId"] = usr.AdminId.ToString();
                Session["AdminUsername"] = usr.AdminUsername.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
            }
            return View();
        }

        //GET: /Admin/LoggedIn
        public ActionResult LoggedIn()
        {
            if (Session["AdminId"] != null)
            {
                return RedirectToAction("Index", "Restaurant");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", admin);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.admin.Find(id);
            db.admin.Remove(admin);
            db.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
