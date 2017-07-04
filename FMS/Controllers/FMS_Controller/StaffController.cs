using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DAL;
using FMS_Objects.Enities;
using PagedList;

namespace FMS.Controllers.FMS_Controller
{

    public class StaffController : System.Web.Mvc.Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /Staff/
        [Route("Staff/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId, string sortOrder, string searchString, string currentFilter, int? page)
        {
            var x = db.restaurant.Find(RestaurantId);
            var staffs = db.staff.Where(s => s.RestaurantId == RestaurantId).ToList();
            Session["rName"] = x.RestaurantName;
            Session["rID"] = RestaurantId;

            ViewBag.StaffFirstNameParm = String.IsNullOrEmpty(sortOrder) ? "StaffFirstName_desc" : "";
            ViewBag.StaffLastNameParm = sortOrder == "StaffLasttName" ? "StaffLastName_desc" : "StaffLastName";
            ViewBag.StaffGenderParm = sortOrder == "StaffGender" ? "StaffGender_desc" : "StaffGender";
            ViewBag.StaffDOEParm = sortOrder == "StaffDOE" ? "StaffDOE_desc" : "StaffDOE";
            ViewBag.StaffDepartmentParm = sortOrder == "StaffDepartment" ? "StaffDepartment_desc" : "StaffDepartment";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var staff = from s in db.staff
                        select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                staff = staff.Where(s => s.StaffFirstName.ToUpper().Contains(searchString.ToUpper()) || s.StaffLastName.ToUpper().Contains(searchString.ToUpper()) || 
                                         s.StaffMiddleName.ToUpper().Contains(searchString.ToUpper()) || s.StaffGender.ToString().Contains(searchString.ToUpper()) ||
                                         s.StaffDepartment.ToString().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "StaffFirstName_desc":
                    staff = staff.OrderByDescending(s => s.StaffFirstName);
                    break;
                case "StaffLastName":
                    staff = staff.OrderBy(s => s.StaffLastName);
                    break;
                case "StaffLastName_desc":
                    staff = staff.OrderByDescending(s => s.StaffLastName);
                    break;
                case "StafGender":
                    staff = staff.OrderBy(s => s.StaffGender);
                    break;
                case "StaffGender_desc":
                    staff = staff.OrderByDescending(s => s.StaffGender);
                    break;
                case "StaffDOE":
                    staff = staff.OrderBy(s => s.StaffDateOfEmployment);
                    break;
                case "StaffaDOE_desc":
                    staff = staff.OrderByDescending(s => s.StaffDateOfEmployment);
                    break;
                case "StaffDepartment":
                    staff = staff.OrderBy(s => s.StaffDepartment);
                    break;
                case "StaffDepartment_desc":
                    staff = staff.OrderByDescending(s => s.StaffDepartment);
                    break;
                default:
                    staff = staff.OrderBy(s => s.StaffFirstName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(staff.ToPagedList(pageNumber, pageSize));
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
                var r = new Staff
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

                db.staff.Add(r);
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
