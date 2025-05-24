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
    public class AK_loginsController : Controller
    {
        private Entities db = new Entities();

        // GET: AK_logins
        public async Task<ActionResult> Index()
        {
            var aK_logins = db.AK_logins.Include(a => a.Ak_Users);
            return View(await aK_logins.ToListAsync());
        }

        // GET: AK_logins/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_logins aK_logins = await db.AK_logins.FindAsync(id);
            if (aK_logins == null)
            {
                return HttpNotFound();
            }
            return View(aK_logins);
        }

        // GET: AK_logins/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Ak_Users, "Id", "UserName");
            return View();
        }

        // POST: AK_logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,userid,username,login_at,login_from")] AK_logins aK_logins)
        {
            if (ModelState.IsValid)
            {
                db.AK_logins.Add(aK_logins);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Ak_Users, "Id", "UserName", aK_logins.userid);
            return View(aK_logins);
        }

        // GET: AK_logins/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_logins aK_logins = await db.AK_logins.FindAsync(id);
            if (aK_logins == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.Ak_Users, "Id", "UserName", aK_logins.userid);
            return View(aK_logins);
        }

        // POST: AK_logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,userid,username,login_at,login_from")] AK_logins aK_logins)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aK_logins).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.Ak_Users, "Id", "UserName", aK_logins.userid);
            return View(aK_logins);
        }

        // GET: AK_logins/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AK_logins aK_logins = await db.AK_logins.FindAsync(id);
            if (aK_logins == null)
            {
                return HttpNotFound();
            }
            return View(aK_logins);
        }

        // POST: AK_logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AK_logins aK_logins = await db.AK_logins.FindAsync(id);
            db.AK_logins.Remove(aK_logins);
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
