using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using FMS_DbConnections.DAL;
using PagedList;
using FMS_Objects.Enities;
namespace FMS.Controllers.FMS_Controller
{
    public class RestaurantController : Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /Restaurant/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int ? page)
        {
            ViewBag.RestaurantNameSortParm = string.IsNullOrEmpty(sortOrder) ? "RestaurantName_desc" : "";
            ViewBag.LGASortParm = sortOrder == "LGA" ? "LGA_desc" : "LGA";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;

            var restaurants = from r in db.restaurant
                              select r;
            if (!string.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(r => r.RestaurantName.ToUpper().Contains(searchString.ToUpper()) || r.LGA.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "RestaurantName_desc":
                    restaurants = restaurants.OrderByDescending(r => r.RestaurantName);
                    break;
                case "LGA":
                    restaurants = restaurants.OrderBy(r => r.LGA);
                    break;
                case "LGA_desc":
                    restaurants = restaurants.OrderByDescending(r => r.LGA);
                    break;

                default:
                    restaurants = restaurants.OrderBy(r => r.RestaurantId);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(restaurants.ToPagedList(pageNumber, pageSize));
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
