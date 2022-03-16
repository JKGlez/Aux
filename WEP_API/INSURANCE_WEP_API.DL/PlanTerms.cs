using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSURANCE_WEP_API.DL
{
    public class PlanTerms //Class for the CSV file
    {
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveTillDate { get; set; }
        public string Actuary { get; set; }
        public string Annuity { get; set; }
        public string Claim { get; set; }
        public string Coverage { get; set; }
        public string DeathBenefit { get; set; }
        public string Deductible { get; set; }
        public string Exclusion { get; set; }
        public string Lapse { get; set; }
        public string Peril { get; set; }
        public string Renewal { get; set; }


        public PlanTerms(string plancode, string planname,string fromdate,string tilldate)
        {
            this.PlanCode = plancode;
            this.PlanName = planname;
            this.EffectiveFromDate = fromdate;
            this.EffectiveTillDate = tilldate;
            this.Actuary = "NA";
            this.Annuity = "NA";
            this.Claim = "NA";
            this.Coverage = "NA";
            this.DeathBenefit = "NA";
            this.Deductible = "NA";
            this.Exclusion = "NA";
            this.Lapse = "NA";
            this.Peril = "NA";
            this.Renewal = "NA";
        }
        public PlanTerms()
        {
            this.PlanCode = "NA";
            this.PlanName = "NA";
            this.EffectiveFromDate = "NA";
            this.EffectiveTillDate = "NA";
            this.Actuary = "NA";
            this.Annuity = "NA";
            this.Claim = "NA";
            this.Coverage = "NA";
            this.DeathBenefit = "NA";
            this.Deductible = "NA";
            this.Exclusion = "NA";
            this.Lapse = "NA";
            this.Peril = "NA";
            this.Renewal = "NA";
        }

    



    }
}
