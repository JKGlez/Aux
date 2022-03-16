import { Plan } from "./plan";
import { PlanDetails } from "./plan-details";
import { Term } from "./term";

export class Request {
    constructor(
        public plan: Plan, 
        public planDetails: PlanDetails, 
        public term: Term
    ){

    }
   
}
