using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class ExpenseItemController : Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /ExpenseItem/
        [Route("ExpenseItem/Index/{ExpenseCategoryId}")]
        public ActionResult Index(int ExpenseCategoryId)
        {
            var x = db.expenseCategory.Find(ExpenseCategoryId);
            Session["ecID"] = x.ExpenseCategoryId;
            Session["ecTitle"] = x.ExpenseCategoryTitle;

            var expenseitem = db.expenseItem.Where(ei => ei.ExpenseCategoryId == ExpenseCategoryId).ToList();
            return View(expenseitem);
        }


        // GET: /ExpenseItem/Create
        public ActionResult Create()
        {
            var expenseitem = new ExpenseItem();
            return PartialView("Create", expenseitem);
        }

        // POST: /ExpenseItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseItem expenseitem)
        {
            if (ModelState.IsValid)
            {
                var EI = new ExpenseItem
                {
                    ExpenseCategoryId = Convert.ToInt32(Session["ecID"]),
                    ExpenseItemTitle = expenseitem.ExpenseItemTitle,
                    ExpenseItemPrice = expenseitem.ExpenseItemPrice,
                    ExpenseItemQuantity = expenseitem.ExpenseItemQuantity
                };
                db.expenseItem.Add(EI);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", expenseitem);
        }

        // GET: /ExpenseItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseitem = db.expenseItem.Find(id);
            if (expenseitem == null)
            {
                return HttpNotFound();
            }
           return PartialView("Edit", expenseitem);
        }

        // POST: /ExpenseItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseItem expenseitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseitem).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", expenseitem);
        }

        // GET: /ExpenseItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseitem = db.expenseItem.Find(id);
            if (expenseitem == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", expenseitem);
        }

        // POST: /ExpenseItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseItem expenseitem = db.expenseItem.Find(id);
            db.expenseItem.Remove(expenseitem);
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
