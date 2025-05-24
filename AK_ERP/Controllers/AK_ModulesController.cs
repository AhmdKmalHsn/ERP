using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AK_HR.Models;

namespace AK_HR.Controllers
{
    public class AK_ModulesController : Controller
    {
        private Entities db = new Entities();

        // GET: AK_Modules
        public async Task<ActionResult> Index()
        {
            return View(await db.AK_Modules.ToListAsync());
        }

        // GET: AK_Modules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_Modules aK_Modules = await db.AK_Modules.FindAsync(id);
            if (aK_Modules == null)
            {
                return HttpNotFound();
            }
            return View(aK_Modules);
        }

        // GET: AK_Modules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AK_Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ModuleName,Title,url,Header,SQLSelect")] AK_Modules aK_Modules)
        {
            if (ModelState.IsValid)
            {
                db.AK_Modules.Add(aK_Modules);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aK_Modules);
        }

        // GET: AK_Modules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_Modules aK_Modules = await db.AK_Modules.FindAsync(id);
            if (aK_Modules == null)
            {
                return HttpNotFound();
            }
            return View(aK_Modules);
        }

        // POST: AK_Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ModuleName,Title,url,Header,SQLSelect")] AK_Modules aK_Modules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aK_Modules).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aK_Modules);
        }

        // GET: AK_Modules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_Modules aK_Modules = await db.AK_Modules.FindAsync(id);
            if (aK_Modules == null)
            {
                return HttpNotFound();
            }
            return View(aK_Modules);
        }

        // POST: AK_Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AK_Modules aK_Modules = await db.AK_Modules.FindAsync(id);
            db.AK_Modules.Remove(aK_Modules);
            await db.SaveChangesAsync();
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
