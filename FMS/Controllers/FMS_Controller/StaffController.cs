using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;
using PagedList;

namespace FMS.Controllers.FMS_Controller
{

    public class StaffController : System.Web.Mvc.Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /Staff/
        [Route("Staff/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            var staffs = db.staff.Where(s => s.RestaurantId == RestaurantId).ToList();
            Session["rName"] = x.RestaurantName;
            Session["rID"] = RestaurantId;

            return View(staffs);
        }

        // GET: /Staff/Create
        public ActionResult Create()
        {
            var staff = new Staff();
            return PartialView("Create", staff);
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var s = new Staff
                {
                    RestaurantId = Convert.ToInt32(Session["rID"]),
                    StaffFirstName = staff.StaffFirstName,
                    StaffLastName = staff.StaffLastName,
                    StaffMiddleName = staff.StaffMiddleName,
                    StaffEmail = staff.StaffEmail,
                    StaffAddress = staff.StaffAddress,
                    StaffGender = staff.StaffGender,
                    StaffPhoneNumber = staff.StaffPhoneNumber,
                    StaffDateOfEmployment = staff.StaffDateOfEmployment,
                    StaffDateOfBirth = staff.StaffDateOfBirth,
                    StaffDepartment = staff.StaffDepartment,
                    StaffAccountName = staff.StaffAccountName,
                    StaffAccountNumber = staff.StaffAccountNumber,
                    StaffBank = staff.StaffBank  
                };

                db.staff.Add(s);
                db.SaveChanges();
                return Json(new { success = true});
            }
            return PartialView("Create", staff);
        }

        // GET: /Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.restaurant, "RestaurantId", "RestaurantName", staff.RestaurantId);
            return PartialView("Edit", staff);
        }

        // POST: /Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.RestaurantId = new SelectList(db.restaurant, "RestaurantId", "RestaurantName", staff.RestaurantId);
            return View("Edit", staff);
        }

        // GET: /Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", staff);
        }

        // POST: /Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.staff.Find(id);
            db.staff.Remove(staff);
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
