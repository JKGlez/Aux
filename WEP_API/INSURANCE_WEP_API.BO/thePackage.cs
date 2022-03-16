
namespace INSURANCE_WEP_API.BO
{
    using System;
    using System.Collections.Generic;

    using System.Runtime.Serialization;
    using INSURANCE_WEP_API.DL;
    

    public class thePackage
    {
        private tbl_plans the_plan;
        private tbl_planDetails the_planDetails;
        private tbl_refterms the_refterms;

        public tbl_plans The_plan { get => the_plan; set => the_plan = value; }
        public tbl_planDetails The_planDetails { get => the_planDetails; set => the_planDetails = value; }
        public tbl_refterms The_refterms { get => the_refterms; set => the_refterms = value; }

        public thePackage(tbl_plans the_plan, tbl_planDetails the_planDetails, tbl_refterms the_refterms)
        {
            this.The_plan = the_plan;
            this.The_planDetails = the_planDetails;
            this.The_refterms = the_refterms;
        }
    }
}
