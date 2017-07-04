using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DAL;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class IncomeItemController : Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /IncomeItem/
        [Route ("IncomeItem/Index/{IncomeCategoryId}")]
        public ActionResult Index(int IncomeCategoryId)
        {
            var x = db.incomeCategory.Find(IncomeCategoryId);
            Session["cTitle"] = x.IncomeCategoryTitle;
            Session["cID"] = IncomeCategoryId;

            var incomeitem = db.incomeItem.Where(IT => IT.IncomeCategoryId == IncomeCategoryId).ToList();
            return View(incomeitem);
        }

        // GET: /IncomeItem/Create
        public ActionResult Create()
        {
           
            var incomeitem = new IncomeItem();
            return PartialView("Create", incomeitem);
        }

        // POST: /IncomeItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeItem incomeitem)
        {
            if (ModelState.IsValid)
            {
                var IC = new IncomeItem
                {
                    IncomeCategoryId = Convert.ToInt32(Session["cID"]),
                    IncomeItemTitle = incomeitem.IncomeItemTitle,
                    IncomeItemPrice = incomeitem.IncomeItemPrice,
                    IncomeItemQuantity = incomeitem.IncomeItemQuantity,
                };
                db.incomeItem.Add(IC);
                db.SaveChanges();
                return Json(new { success = true});
            }

            return PartialView("Create", incomeitem);
        }

        // GET: /IncomeItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeItem incomeitem = db.incomeItem.Find(id);
            if (incomeitem == null)
            {
                return HttpNotFound();
            }
            
            return PartialView("Edit", incomeitem);
        }

        // POST: /IncomeItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeItem incomeitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeitem).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", incomeitem);
        }

        // GET: /IncomeItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeItem incomeitem = db.incomeItem.Find(id);
            if (incomeitem == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", incomeitem);
        }

        // POST: /IncomeItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeItem incomeitem = db.incomeItem.Find(id);
            db.incomeItem.Remove(incomeitem);
            db.SaveChanges();
            return Json(new { sucess = true });
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
