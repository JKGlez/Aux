using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using INSURANCE_WEP_API.DL;
using INSURANCE_WEP_API.BO;


namespace INSURANCE_WEP_API.Controllers
{
    public class PackageController : ApiController
    {

        private INSURANCE_DBEntities db = new INSURANCE_DBEntities();

        [HttpPost]
        public async Task<IHttpActionResult> Post(thePackage thePackage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Console.WriteLine("Aprove it");
                Console.WriteLine(thePackage);
                db.tbl_plans.Add(thePackage.The_plan);
                db.tbl_planDetails.Add(thePackage.The_planDetails);
                db.tbl_refterms.Add(thePackage.The_refterms);
                db.SaveChanges();
                Console.WriteLine("Pause");
            }
            return Ok();
        }
    }
}
