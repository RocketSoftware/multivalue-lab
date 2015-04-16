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
    public class CustomerController : Controller
    {
        private Entities db = new Entities();

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            return View(await db.CUSTOMERs.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CUSTID,SAL,FNAME,LNAME,FULLNAME,COMPANY,ADDR1,ADDR2,FULLADDR,CITY,STATE,STATENAME,ZIP,PHONE")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERs.Add(cUSTOMER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cUSTOMER);
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CUSTID,SAL,FNAME,LNAME,FULLNAME,COMPANY,ADDR1,ADDR2,FULLADDR,CITY,STATE,STATENAME,ZIP,PHONE")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cUSTOMER);
        }

        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CUSTOMER cUSTOMER = await db.CUSTOMERs.FindAsync(id);
            db.CUSTOMERs.Remove(cUSTOMER);
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
