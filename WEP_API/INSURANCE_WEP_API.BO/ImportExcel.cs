using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSURANCE_WEP_API.DL;

namespace INSURANCE_WEP_API.BO
{
    public class ImportExcel
    {
        private tbl_plans thePlan;
        private PlanFeatures[] planFeatures;

        public tbl_plans ThePlan { get => thePlan; set => thePlan = value; }
        public PlanFeatures[] PlanFeatures { get => planFeatures; set => planFeatures = value; }

        public ImportExcel(tbl_plans thePlan, PlanFeatures[] planFeatures)
        {
            this.ThePlan = thePlan;
            this.PlanFeatures = planFeatures;
        }
    }
}
