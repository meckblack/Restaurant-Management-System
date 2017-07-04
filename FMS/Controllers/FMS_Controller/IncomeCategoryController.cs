using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DAL;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class IncomeCategoryController : Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /IncomeCategory/
        [Route("IncomeCategory/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["ricName"] = x.RestaurantName;
            Session["ricID"] = RestaurantId;

            var incomecategory = db.incomeCategory.Where(ic => ic.RestaurantId == RestaurantId).ToList();
            return View(incomecategory);
        }

        
        // GET: /IncomeCategory/Create
        public ActionResult Create()
        {
            var incomecategory = new IncomeCategory();
            return PartialView("Create", incomecategory);
        }

        // POST: /IncomeCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeCategory incomecategory)
        {
            if (ModelState.IsValid)
            {
                var IC = new IncomeCategory
                {
                    RestaurantId = Convert.ToInt32(Session["ricID"]),
                    IncomeCategoryTitle = incomecategory.IncomeCategoryTitle,
                    IncomeCategoryDescription = incomecategory.IncomeCategoryDescription,
                };
                db.incomeCategory.Add(IC);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", incomecategory);
        }

        // GET: /IncomeCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategory incomecategory = db.incomeCategory.Find(id);
            if (incomecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", incomecategory);
        }

        // POST: /IncomeCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeCategory incomecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomecategory).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", incomecategory);
        }

        // GET: /IncomeCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategory incomecategory = db.incomeCategory.Find(id);
            if (incomecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", incomecategory);
        }

        // POST: /IncomeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeCategory incomecategory = db.incomeCategory.Find(id);
            db.incomeCategory.Remove(incomecategory);
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
