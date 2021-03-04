using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QwiloMVCStore.Models;

namespace QwiloMVCStore.Controllers
{
    public class MasterCategoriesController : Controller
    {
        private QwiloStoreContext db = new QwiloStoreContext();

        // GET: MasterCategories
        public ActionResult Index(int? id) // int? = nullable, so requests to MasterCategories/Index don't need an ID.
        {
            // Create list to contain ints
            var PossibleMainCategoryIDs = new List<int>();

            // Query database for all parent IDs
            var getMainCategoryIDsQuery = from entries in db.Products
                                    orderby entries.MainCategoryID
                                    select entries.MainCategoryID;

            // After getting all parent IDs, add all *distinct* values to the list.
            PossibleMainCategoryIDs.AddRange(getMainCategoryIDsQuery.Distinct());
            

            // Now, create another query to get all the categories.
            var categoryProducts = from entries in db.Products
                                   select entries;



            // Filter categories if user specified a valid category.
            if (id != null && PossibleMainCategoryIDs.Contains((int)id)) {
                categoryProducts = categoryProducts.Where(entry => entry.MainCategoryID == id);

                // Get category and categoryIDs into  ViewBag for use in the View.
                string category = db.MasterCategories.Where(col => col.Id == id).Select(e => e.CategoryName).Single().Trim();
                ViewBag.Category = category;
                ViewBag.CategoryID = id;
            }

            // Last check to make sure that they're not null.
            ViewBag.Category = ViewBag.Category ?? "All";
            ViewBag.CategoryID = ViewBag.CategoryID ?? 0;


            return View(categoryProducts);

            // Extra note:
            // The default parameter for assigned to the return statement View() (seen below) gets all entries.
            // db.MasterCategories.ToList()

        }

        // GET: MasterCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // GET: MasterCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryID,CategoryName,Parent")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                db.MasterCategories.Add(masterCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterCategory);
        }

        // GET: MasterCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // POST: MasterCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryID,CategoryName,Parent")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterCategory);
        }

        // GET: MasterCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // POST: MasterCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            db.MasterCategories.Remove(masterCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
