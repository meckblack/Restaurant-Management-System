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
    public class FoodController : Controller
    {
        private StaffDataContext db = new StaffDataContext();

        // GET: /Food/
        [Route("Food/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["rNamee"] = x.RestaurantName;
            Session["rID"] = x.RestaurantId;
            
            var food = db.food.Where(f => f.RestaurantId == RestaurantId).ToList();
            return View(food);
        }

        // GET: /Food/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Food food = db.food.Find(id);
        //    if (food == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(food);
        //}

        // GET: /Food/Create
        public ActionResult Create()
        {
            var food = new Food();
            return PartialView("Create", food);
        }

        // POST: /Food/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FoodId,FoodImage,FoodName,FoodType,FoodPrice,FoodDescription,RestaurantId")] Food food)
        {
            if (ModelState.IsValid)
            {
                var f = new Food
                {
                    RestaurantId = Convert.ToInt32(Session["rID"]),
                    FoodName = food.FoodName,
                    FoodImage = food.FoodImage,
                    FoodDescription = food.FoodDescription,
                    FoodPrice = food.FoodPrice,
                    FoodType = food.FoodType,
                };

                db.food.Add(f);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("Create", food);
        }

        // GET: /Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", food);
        }

        // POST: /Food/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FoodId,FoodImage,FoodName,FoodType,FoodPrice,FoodDescription,RestaurantId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.RestaurantId = new SelectList(db.restaurant, "RestaurantId", "RestaurantName", food.RestaurantId);
            return View(food);
        }

        // GET: /Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.food.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", food);
        }

        // POST: /Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.food.Find(id);
            db.food.Remove(food);
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
