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
        public ActionResult Index(int? id)
        {
            // Create list to contain ints
            var PossibleParentIDs = new List<int>();

            // Query database for all parent IDs
            var getParentIDsQuery = from entries in db.MasterCategories
                                    orderby entries.Parent
                                    select entries.Parent;

            // After getting all parent IDs, add all *distinct* values to the list.
            PossibleParentIDs.AddRange(getParentIDsQuery.Distinct());

            // Now, create another query to get all the categories.
            var categories = from entries in db.MasterCategories
                             select entries;

            // Filter categories if user specified a valid category.
            if (id != null && PossibleParentIDs.Contains((int)id)) {
                categories = categories.Where(entry => entry.Parent == id);
            }

            return View(categories);

            // Extra note:
            // db.MasterCategories.ToList()
            // The default parameter for View -- gets all entries.
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
