export class Plan {
    constructor(
        public PlanId: number,
        public PlanCode: string, 
        public PlanName: string, 
        public EffectiveFromDate: Date,
        public EffectiveTillDate: Date,
        public CreatedDate: Date|null, 
        public ModifiedDate: Date|null, 
        public CreatedUser: number, 
        public ModifiedUser: number, 
    ){

    }
}
