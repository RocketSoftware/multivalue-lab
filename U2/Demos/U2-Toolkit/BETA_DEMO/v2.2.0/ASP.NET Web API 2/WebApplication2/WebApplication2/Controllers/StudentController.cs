using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class StudentController : ApiController
    {
        private demoEntities db = new demoEntities();

        // GET: api/Student
        public IQueryable<STUDENT_NF_SUB> GetSTUDENT_NF_SUB()
        {
            return db.STUDENT_NF_SUB;
        }

        // GET: api/Student/5
        [ResponseType(typeof(STUDENT_NF_SUB))]
        public async Task<IHttpActionResult> GetSTUDENT_NF_SUB(string id)
        {
            STUDENT_NF_SUB sTUDENT_NF_SUB = await db.STUDENT_NF_SUB.FindAsync(id);
            if (sTUDENT_NF_SUB == null)
            {
                return NotFound();
            }

            return Ok(sTUDENT_NF_SUB);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSTUDENT_NF_SUB(string id, STUDENT_NF_SUB sTUDENT_NF_SUB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTUDENT_NF_SUB.ID)
            {
                return BadRequest();
            }

            db.Entry(sTUDENT_NF_SUB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STUDENT_NF_SUBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student
        [ResponseType(typeof(STUDENT_NF_SUB))]
        public async Task<IHttpActionResult> PostSTUDENT_NF_SUB(STUDENT_NF_SUB sTUDENT_NF_SUB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STUDENT_NF_SUB.Add(sTUDENT_NF_SUB);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (STUDENT_NF_SUBExists(sTUDENT_NF_SUB.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTUDENT_NF_SUB.ID }, sTUDENT_NF_SUB);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(STUDENT_NF_SUB))]
        public async Task<IHttpActionResult> DeleteSTUDENT_NF_SUB(string id)
        {
            STUDENT_NF_SUB sTUDENT_NF_SUB = await db.STUDENT_NF_SUB.FindAsync(id);
            if (sTUDENT_NF_SUB == null)
            {
                return NotFound();
            }

            db.STUDENT_NF_SUB.Remove(sTUDENT_NF_SUB);
            await db.SaveChangesAsync();

            return Ok(sTUDENT_NF_SUB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STUDENT_NF_SUBExists(string id)
        {
            return db.STUDENT_NF_SUB.Count(e => e.ID == id) > 0;
        }
    }
}