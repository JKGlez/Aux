import { Term } from "./term";

export class PlanDetails {
    constructor(
        public PlanDetailsId: number|null,
        public PlanId: number|null,
        public TermId: number|null,
        public TermValue: string|null,
        public CreatedDate: Date|null,
        public ModifiedDate: Date|null,
        public CreatedUser: number|null,
        public ModifiedUser: number|null,
        public tbl_refterms: Term|null
    ){

    }

}
