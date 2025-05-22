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
    public class Ak_UsersController : Controller
    {
        private Entities db = new Entities();

        // GET: Ak_Users
        public async Task<ActionResult> Index()
        {
            var ak_Users = db.Ak_Users.Include(a => a.AK_Roles);
            return View(await ak_Users.ToListAsync());
        }

        // GET: Ak_Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ak_Users ak_Users = await db.Ak_Users.FindAsync(id);
            if (ak_Users == null)
            {
                return HttpNotFound();
            }
            return View(ak_Users);
        }

        // GET: Ak_Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.AK_Roles, "Id", "role_name");
            return View();
        }

        // POST: Ak_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Password,Name,RoleId,Image,All,Departments,Employees,HaveApprove,ApproveId,UserType,Parent,StageClass,ip_restrict,active,login_at,login_to,login_permit,token")] Ak_Users ak_Users)
        {
            if (ModelState.IsValid)
            {
                db.Ak_Users.Add(ak_Users);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.AK_Roles, "Id", "role_name", ak_Users.RoleId);
            return View(ak_Users);
        }

        // GET: Ak_Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ak_Users ak_Users = await db.Ak_Users.FindAsync(id);
            if (ak_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.AK_Roles, "Id", "role_name", ak_Users.RoleId);
            return View(ak_Users);
        }

        // POST: Ak_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,Password,Name,RoleId,Image,All,Departments,Employees,HaveApprove,ApproveId,UserType,Parent,StageClass,ip_restrict,active,login_at,login_to,login_permit,token")] Ak_Users ak_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ak_Users).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.AK_Roles, "Id", "role_name", ak_Users.RoleId);
            return View(ak_Users);
        }

        // GET: Ak_Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ak_Users ak_Users = await db.Ak_Users.FindAsync(id);
            if (ak_Users == null)
            {
                return HttpNotFound();
            }
            return View(ak_Users);
        }

        // POST: Ak_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ak_Users ak_Users = await db.Ak_Users.FindAsync(id);
            db.Ak_Users.Remove(ak_Users);
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
