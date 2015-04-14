using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class StateController : Controller
    {
        private Entities db = new Entities();

        // GET: State
        public async Task<ActionResult> Index()
        {
            return View(await db.STATES.ToListAsync());
        }

        // GET: State/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = await db.STATES.FindAsync(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            return View(sTATE);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODE,NAME")] STATE sTATE)
        {
            if (ModelState.IsValid)
            {
                db.STATES.Add(sTATE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sTATE);
        }

        // GET: State/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = await db.STATES.FindAsync(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            return View(sTATE);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODE,NAME")] STATE sTATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTATE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sTATE);
        }

        // GET: State/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = await db.STATES.FindAsync(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            return View(sTATE);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            STATE sTATE = await db.STATES.FindAsync(id);
            db.STATES.Remove(sTATE);
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
