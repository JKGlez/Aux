using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
//using INSURANCE_WEP_API.Models;
using INSURANCE_WEP_API.DL;
namespace INSURANCE_WEP_API.Controllers
{
    public class tbl_planDetailsController : ApiController
    {
        private INSURANCE_DBEntities db = new INSURANCE_DBEntities();

        // GET: api/tbl_planDetails
        public IQueryable<tbl_planDetails> Gettbl_planDetails()
        {
            return db.tbl_planDetails;
        }

        // GET: api/tbl_planDetails/5
        [ResponseType(typeof(tbl_planDetails))]
        public IHttpActionResult Gettbl_planDetails(long id)
        {
            tbl_planDetails tbl_planDetails = db.tbl_planDetails.Find(id);
            if (tbl_planDetails == null)
            {
                return NotFound();
            }

            return Ok(tbl_planDetails);
        }

        // PUT: api/tbl_planDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_planDetails(long id, tbl_planDetails tbl_planDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_planDetails.PlanDetailsId)
            {
                return BadRequest();
            }

            db.Entry(tbl_planDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_planDetailsExists(id))
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

        // POST: api/tbl_planDetails
        [ResponseType(typeof(tbl_planDetails))]
        public IHttpActionResult Posttbl_planDetails(tbl_planDetails tbl_planDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_planDetails.Add(tbl_planDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_planDetails.PlanDetailsId }, tbl_planDetails);
        }

        // DELETE: api/tbl_planDetails/5
        [ResponseType(typeof(tbl_planDetails))]
        public IHttpActionResult Deletetbl_planDetails(long id)
        {
            tbl_planDetails tbl_planDetails = db.tbl_planDetails.Find(id);
            if (tbl_planDetails == null)
            {
                return NotFound();
            }

            db.tbl_planDetails.Remove(tbl_planDetails);
            db.SaveChanges();

            return Ok(tbl_planDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_planDetailsExists(long id)
        {
            return db.tbl_planDetails.Count(e => e.PlanDetailsId == id) > 0;
        }
    }
}