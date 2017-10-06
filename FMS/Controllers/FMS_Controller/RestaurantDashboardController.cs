using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;

namespace FMS.Controllers.FMS_Controller
{
    public class RestaurantDashboardController : Controller
    {
        private StaffDataContext db = new StaffDataContext();
        //
        // GET: /RestaurantDashboard/

        [Route("RestaurantDashboard/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["rName"] = x.RestaurantName;
            Session["rAcronym"] = x.RestaurantAcronym;
            Session["rAddress"] = x.RestaurantAddress;
            Session["rLGA"] = x.LGA;
            Session["rPostalCode"] = x.PostalCode;
            Session["rCountry"] = x.Country;

            Session["rID"] = RestaurantId;
            return View();
        }

        // GET: /Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", restaurant);
        }

        // POST: /Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId, RestaurantName, RestaurantAcronym, RestaurantAddress, LGA, Country, PostalCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", restaurant);
        }

        // GET: /Restaurant/Delete/5
        /*public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", restaurant);
        }

        // POST: /Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.restaurant.Find(id);
            db.restaurant.Remove(restaurant);
            db.SaveChanges();
            //return Json(new { success = true });
            return RedirectToAction("Done");
        }*/

        
	}
}