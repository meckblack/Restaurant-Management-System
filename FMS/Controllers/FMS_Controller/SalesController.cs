using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FMS_DbConnections.DAL;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class SalesController : Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /Sales/
        [Route("Sales/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["rNames"] = x.RestaurantName;
            Session["rIDs"] = x.RestaurantId;
            var sales = db.sales.Where(s => s.RestaurantId == RestaurantId).ToList();
            return View(sales   );
        }


        // GET: /Sales/Create
        public ActionResult Create()
        {
            var sales = new Sales();
            return PartialView("Create", sales);
        }

        // POST: /Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,SaleTitle,SaleAmount,SaleQuantity,RestaurantId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                var s = new Sales
                {
                    RestaurantId = Convert.ToInt32(Session["rIDs"]),
                    SaleTitle = sales.SaleTitle,
                    SaleAmount = sales.SaleAmount,
                    SaleQuantity = sales.SaleQuantity
                };

                db.sales.Add(s);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", sales);
        }

        // GET: /Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", sales);
        }

        // POST: /Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,SaleTitle,SaleAmount,SaleQuantity,RestaurantId")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Edit", sales);
        }

        // GET: /Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", sales);
        }

        // POST: /Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.sales.Find(id);
            db.sales.Remove(sales);
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
