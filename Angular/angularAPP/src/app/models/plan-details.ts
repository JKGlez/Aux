export class PlanDetails {
    constructor(
        public PlanDetailsId: number, 
        public PlanId: number, 
        public TermId: number, 
        public TermValue: number,
        public CreatedDate: Date|null, 
        public ModifiedDate: Date|null, 
        public CreatedUser: number, 
        public ModifiedUser: number,
    ){

    }

}
