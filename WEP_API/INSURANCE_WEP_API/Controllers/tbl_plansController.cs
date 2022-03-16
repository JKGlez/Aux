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
using INSURANCE_WEP_API.BO;

namespace INSURANCE_WEP_API.Controllers
{
    public class tbl_plansController : ApiController
    {
        private INSURANCE_DBEntities db = new INSURANCE_DBEntities();

        // GET: api/tbl_plans
        public IHttpActionResult Gettbl_plans()
        {
            return Ok(db.tbl_plans);
        }

        // GET: api/tbl_plans/5
        [ResponseType(typeof(tbl_plans))]
        public IHttpActionResult Gettbl_plans(long id)
        {
            tbl_plans tbl_plans = db.tbl_plans.Find(id);
            if (tbl_plans == null)
            {
                return NotFound();
            }

            return Ok(tbl_plans);
        }
        [Route("api/getPlanFeatures")]
        [HttpGet]
        public IHttpActionResult GetPlanFeatures(string code)
        {
            try
            {

                //var plans = db.tbl_planDetails.Where(d => d.pl.Equals(id)).ToList();
                var planCode = db.tbl_plans.Where(d => d.PlanCode.Equals(code)).FirstOrDefault();
                var plansDetails = db.tbl_planDetails.Where(d => d.PlanId.Equals(planCode.PlanId)).ToList();
                //IEnumerable<PlanFeatures> plansAssociated = new PlanFeatures[];
                var plansAssociated = new List<PlanFeatures>();

                if (plansDetails.Count != 0)
                {
                    foreach (var plan in plansDetails)
                    {
                        tbl_refterms termN = db.tbl_refterms.Where(x => x.TermId.Equals(plan.TermId)).FirstOrDefault();
                        plansAssociated.Add(new PlanFeatures(termN.TermName, plan.TermValue));

                    }
                    return Ok(plansAssociated);
                }
                return BadRequest("There was a problem retrieving the  plans");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return BadRequest("There is a problem retrieving the data");
            }
        }

        // PUT: api/tbl_plans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_plans(long id, tbl_plans tbl_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_plans.PlanId)
            {
                return BadRequest();
            }

            db.Entry(tbl_plans).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_plansExists(id))
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

        // POST: api/tbl_plans
        [ResponseType(typeof(tbl_plans))]
        public IHttpActionResult Posttbl_plans(tbl_plans tbl_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_plans.Add(tbl_plans);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_plans.PlanId }, tbl_plans);
        }

        // DELETE: api/tbl_plans/5
        [ResponseType(typeof(tbl_plans))]
        public IHttpActionResult Deletetbl_plans(long id)
        {
            tbl_plans tbl_plans = db.tbl_plans.Find(id);
            if (tbl_plans == null)
            {
                return NotFound();
            }

            db.tbl_plans.Remove(tbl_plans);
            db.SaveChanges();

            return Ok(tbl_plans);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_plansExists(long id)
        {
            return db.tbl_plans.Count(e => e.PlanId == id) > 0;
        }
    }
}