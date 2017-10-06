using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class ExpenseCategoryController : Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /ExpenseCategory/
        [Route("ExpenseCategory/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["recNamee"] = x.RestaurantName;
            Session["recID"] = RestaurantId;

            var expensecategory = db.expenseCategory.Where(ic => ic.RestaurantId == RestaurantId).ToList();
            return View(expensecategory);
        }


        // GET: /ExpenseCategory/Create
        public ActionResult Create()
        {
            var expensecategory = new ExpenseCategory();
            return PartialView("Create", expensecategory);
        }

        // POST: /ExpenseCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                var EC = new ExpenseCategory
                {
                    RestaurantId = Convert.ToInt32(Session["recID"]),
                    ExpenseCategoryTitle = expensecategory.ExpenseCategoryTitle,
                    ExpenseCategoryDescription = expensecategory.ExpenseCategoryDescription,
                };
                db.expenseCategory.Add(EC);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", expensecategory);
        }

        // GET: /ExpenseCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expensecategory = db.expenseCategory.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", expensecategory);
        }

        // POST: /ExpenseCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseCategory expensecategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensecategory).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", expensecategory);
        }

        // GET: /ExpenseCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expensecategory = db.expenseCategory.Find(id);
            if (expensecategory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", expensecategory);
        }

        // POST: /ExpenseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCategory expensecategory = db.expenseCategory.Find(id);
            db.expenseCategory.Remove(expensecategory);
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
