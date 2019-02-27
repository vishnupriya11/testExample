using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCurd.Models;

namespace MVCCurd.Controllers
{
    public class emp_infoController : Controller
    {
        private emp_detailsEntities db = new emp_detailsEntities();

        // GET: emp_info
        public ActionResult Index()



        {
            return View(db.emp_info.ToList());
        }

        // GET: emp_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_info emp_info = db.emp_info.Find(id);
            if (emp_info == null)
            {
                return HttpNotFound();
            }
            return View(emp_info);
        }

        // GET: emp_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emp_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_name,emp_dept,contact_no,address")] emp_info emp_info)
        {
            if (ModelState.IsValid)
            {
                db.emp_info.Add(emp_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp_info);
        }

        // GET: emp_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_info emp_info = db.emp_info.Find(id);
            if (emp_info == null)
            {
                return HttpNotFound();
            }
            return View(emp_info);
        }

        // POST: emp_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_name,emp_dept,contact_no,address")] emp_info emp_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp_info);
        }

        // GET: emp_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp_info emp_info = db.emp_info.Find(id);
            if (emp_info == null)
            {
                return HttpNotFound();
            }
            return View(emp_info);
        }

        // POST: emp_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emp_info emp_info = db.emp_info.Find(id);
            db.emp_info.Remove(emp_info);
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
