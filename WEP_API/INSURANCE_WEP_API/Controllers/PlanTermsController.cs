using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using INSURANCE_WEP_API.DL;
using INSURANCE_WEP_API.BO;
using System.Threading.Tasks;

namespace INSURANCE_WEP_API.Controllers
{
    public class PlanTermsController : ApiController
    {
        private INSURANCE_DBEntities db = new INSURANCE_DBEntities();



        [HttpPost]
        public async Task<IHttpActionResult> Post(IEnumerable<tbl_plans> obj_ImportedDataExcel)
        //public async Task<IHttpActionResult> Post(ImportExcel obj_ImportedDataExcel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Console.WriteLine("Model aprove it");
                var PlansAtDB = db.tbl_plans.ToList();
                var RefTermsAtDB = db.tbl_refterms.ToList();
                foreach (tbl_plans CurrentPlan in obj_ImportedDataExcel)
                {
                    //SetFormatForDB(CurrentPlan);

                    //Set the TimeStamp for Dates.
                    //CurrentPlan.ThePlan.CreatedDate = System.DateTime.Now;
                    //CurrentPlan.ThePlan.ModifiedDate = System.DateTime.Now;

                    //List < tbl_plans > ClearPlan = new List<tbl_plans>();

                    //foreach (PlanFeatures currentPlanFeature in CurrentPlan.PlanFeatures)
                    //{
                    //    if (!currentPlanFeature.TermValue.Equals("NA"))
                    //    {
                    //        ClearPlanFeatures.Add(currentPlanFeature);
                    //        Console.WriteLine("Pause");
                    //    }
                    //}

                   

                    //var CurrentPlanID = PlansAtDB.ToList().Where(p => p.PlanCode.Equals(CurrentPlan.ThePlan.PlanCode));

                    //var existPlan = PlansAtDB.ToList().Where(p => p.PlanCode.Equals(CurrentPlan.ThePlan.PlanCode));

                    



                    //var found = plans.Contains(CurrentPlan);

                    Console.WriteLine("Pause");

                    

                    //db.tbl_plans.Add(CurrentPlan.ThePlan);

                }

                ////db.SaveChanges();
                Console.WriteLine("Pause");
            }
            return Ok();
        }

        //public void SetFormatForDB(ImportExcel CurrentPlan)
        //{
        //    //Set the TimeStamp for Dates.
        //    //CurrentPlan.ThePlan.CreatedDate = System.DateTime.Now;
        //    //CurrentPlan.ThePlan.ModifiedDate = System.DateTime.Now;

        //    //List<PlanFeatures> ClearPlanFeatures = new List<PlanFeatures>();

        //    //foreach (PlanFeatures currentPlanFeature in CurrentPlan.PlanFeatures)
        //    //{
        //    //    if (!currentPlanFeature.TermValue.Equals("NA"))
        //    //    {
        //    //        ClearPlanFeatures.Add(currentPlanFeature);
        //    //    }
        //    //}
        //    //Console.WriteLine("Pause");


        //}
    }
}
