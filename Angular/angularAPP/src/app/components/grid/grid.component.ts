import { Component, OnInit } from '@angular/core';
import { Plan } from 'src/app/models/plan';
import { PlanService } from 'src/app/services/plan.service';
import { TermService } from 'src/app/services/term.service';
import { Term } from 'src/app/models/term';
@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {
  public arrayPlans: Plan[]=[];
  public bln_showPlanForm: boolean=false;
  closeResult = '';
  public planCode: string;
  public operation: string;
   public planToEdit: Plan;


  constructor( 
    private _PlanService: PlanService,
    private _TermService: TermService,
  ) { 
    
   
  }

  ngOnInit(): void {
    this.bln_showPlanForm=false;
    this._PlanService.GetAllPlans().subscribe({
      next: (data)=>{
        console.log(data);
        this.arrayPlans=data;
      }, 
      error: (error)=>{
        console.log(error);
      }, 
      complete: ()=>{
        
      }
    });

}

showNewPlanForm(){
  this.bln_showPlanForm=true;
  this.operation="add"
}

showEditForm(plan: Plan){
  this.bln_showPlanForm=true;
  this.operation="edit"
   this.planToEdit=plan;

}


openModal(plancode: number){
console.log(plancode);
this.planCode=plancode.toString();
}


setOperationToAdd(){
  this.operation="add";
  this.planToEdit=null;
}
setOperationToEdit(plan: Plan){
  console.log("function: set operation to edit");
  console.log(plan);
  this.planToEdit=plan;
  this.operation="edit";
}





}
