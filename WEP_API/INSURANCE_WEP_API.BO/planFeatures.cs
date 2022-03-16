using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSURANCE_WEP_API.BO
{
    public class PlanFeatures
    {
        public string TermName { get; set; }
        public string TermValue { get; set; }

        public PlanFeatures(string termname, string termvalue)
        {
            this.TermName = termname;
            this.TermValue = termvalue;
        }

    }
}
