using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INSURANCE_WEP_API.DL;

namespace INSURANCE_WEP_API.BO
{
    public class PlanTermsArray
    {
        private IEnumerable<PlanTerms> obj_PlanTermsArray;

        public IEnumerable<PlanTerms> Obj_PlanTermsArray { get => obj_PlanTermsArray; set => obj_PlanTermsArray = value; }


        public PlanTermsArray(IEnumerable<PlanTerms> obj_PlanTermsArray)
        {
            this.Obj_PlanTermsArray = obj_PlanTermsArray;
        }

    }
}
