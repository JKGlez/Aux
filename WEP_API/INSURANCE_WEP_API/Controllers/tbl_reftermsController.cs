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
    public class tbl_reftermsController : ApiController
    {
        private INSURANCE_DBEntities db = new INSURANCE_DBEntities();

        // GET: api/tbl_refterms
        public IQueryable<tbl_refterms> Gettbl_refterms()
        {
            return db.tbl_refterms;
        }

        // GET: api/tbl_refterms/5
        [ResponseType(typeof(tbl_refterms))]
        public IHttpActionResult Gettbl_refterms(long id)
        {
            tbl_refterms tbl_refterms = db.tbl_refterms.Find(id);
            if (tbl_refterms == null)
            {
                return NotFound();
            }

            return Ok(tbl_refterms);
        }

        // PUT: api/tbl_refterms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_refterms(long id, tbl_refterms tbl_refterms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_refterms.TermId)
            {
                return BadRequest();
            }

            db.Entry(tbl_refterms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_reftermsExists(id))
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

        // POST: api/tbl_refterms
        [ResponseType(typeof(tbl_refterms))]
        public IHttpActionResult Posttbl_refterms(tbl_refterms tbl_refterms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_refterms.Add(tbl_refterms);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_refterms.TermId }, tbl_refterms);
        }

        // DELETE: api/tbl_refterms/5
        [ResponseType(typeof(tbl_refterms))]
        public IHttpActionResult Deletetbl_refterms(long id)
        {
            tbl_refterms tbl_refterms = db.tbl_refterms.Find(id);
            if (tbl_refterms == null)
            {
                return NotFound();
            }

            db.tbl_refterms.Remove(tbl_refterms);
            db.SaveChanges();

            return Ok(tbl_refterms);
        }
        /*
        [Route("api/getCSVs")]
        [HttpGet]
        public IHttpActionResult GeTCSV()
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pathProject = System.Web.Hosting.HostingEnvironment.MapPath($@"~/CSV_files/");
                ToCSVClass newCSV = new ToCSVClass();
                List<string> tables = newCSV.GetTableNames();
                List<string> final_list = new List<string>();
                if (tables.Count != 0)
                {
                    foreach (var tb in tables)
                    {

                        string file = path + $"\\ {tb}.csv";
                        string fileProject = pathProject + $"\\ {tb}.csv";
                        //string fileProject = System.Web.Hosting.HostingEnvironment.MapPath($@"~/CSV_files/{tb}.csv");
                        newCSV.GetCSV(tb, fileProject);
                        newCSV.GetCSV(tb, file);
                    }
                    return Ok(pathProject);
                }
                else
                {
                    return BadRequest("There is a problem retrieving the data");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
    

        }
            */
        [Route("api/GetCSV")]
        [HttpGet]
        public IHttpActionResult GetTable()
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pathProject = System.Web.Hosting.HostingEnvironment.MapPath($@"~/CSV_files/");
                ToCSVClass newCSV = new ToCSVClass();
                string csvFilePath = path + "\\PlansTerms.csv";
                string fileProject = pathProject + "\\PlanTerms.csv";
                newCSV.PlanTermsCheckFile(csvFilePath);
                string result = newCSV.PlanTermsCheckFile(fileProject);
                return Ok(result);



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_reftermsExists(long id)
        {
            return db.tbl_refterms.Count(e => e.TermId == id) > 0;
        }
    }
}