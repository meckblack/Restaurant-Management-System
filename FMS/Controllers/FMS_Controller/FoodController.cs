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
    public class FoodController : Controller
    {
        private FMS_DB db = new FMS_DB();

        // GET: /Food/
        [Route("Food/Index/{RestaurantId}")]
        public ActionResult Index(int RestaurantId, string sortOrder, string searchString, string currentFilter, int ? page)
        {
            var x = db.restaurant.Find(RestaurantId);
            Session["rNamee"] = x.RestaurantName;
            Session["rID"] = x.RestaurantId;
            
            var food = db.food.Where(f => f.RestaurantId == RestaurantId).ToList();

            ViewBag.FoodNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FoodName_desc" : "";
            ViewBag.FoodTypeSortParm = sortOrder == "FoodType" ? "FoodType_desc" : "FoodType";
            
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;

            var foods = from f in db.food
                       select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(f => f.FoodName.ToUpper().Contains(searchString.ToUpper()) || f.FoodType.ToString().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "FoodName_desc":
                    foods = foods.OrderByDescending(f => f.FoodName);
                    break;
                case "FoodType":
                    foods = foods.OrderBy(f => f.FoodType);
                    break;
                case "FoodType_desc":
                    foods = foods.OrderByDescending(f => f.FoodType);
                    break;
                default:
                    foods = foods.OrderBy(f => f.FoodName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(foods.ToPagedList(pageNumber, pageSize));
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
