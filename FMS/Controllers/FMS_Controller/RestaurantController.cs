using System.Linq;
using System.Net;
using System.Web.Mvc;

using FMS_DbConnections.DataContext.StaffDataContext;
using FMS_Objects.Enities;
namespace FMS.Controllers.FMS_Controller
{
    public class RestaurantController : Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /Restaurant/
        public ActionResult Index()
        {   
            return View(db.restaurant.ToList());
        }

       
        // GET: /Restaurant/Create
        public ActionResult Create()
        {
            var restaurant = new Restaurant();
            return PartialView("Create", restaurant);
        }

        // POST: /Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RestaurantId,RestaurantName,RestaurantAcronym,RestaurantAddress,LGA,Country,PostalCode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.restaurant.Add(restaurant);
                db.SaveChanges();
                return Json(new { success = true });
            }


            return PartialView("Create", restaurant);
        }

        // GET: /Restaurant/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Restaurant restaurant = db.restaurant.Find(id);
        //    if (restaurant == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView("Edit", restaurant);
        //}

        // POST: /Restaurant/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="RestaurantId, RestaurantName, RestaurantAcronym, RestaurantAddress, LGA, Country, PostalCode")] Restaurant restaurant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(restaurant).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return PartialView("Edit", restaurant);
        //}

        // GET: /Restaurant/Delete/5
        public ActionResult Delete(int? id)
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
            return PartialView("Delete" ,restaurant);
        }

        // POST: /Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.restaurant.Find(id);
            db.restaurant.Remove(restaurant);
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
