import { PlanDetails } from "./plan-details";

export class Plan {
    constructor(
        public PlanId: number|null,
        public PlanCode: string|null,
        public PlanName: string|null,
        public EffectiveFromDate: Date|null,
        public EffectiveTillDate: Date|null,
        public CreatedDate: Date|null,
        public ModifiedDate: Date|null,
        public CreatedUser: number|null,
        public ModifiedUser: number|null,
        public tbl_planDetails: PlanDetails[]=[]
    ){

    }


}
