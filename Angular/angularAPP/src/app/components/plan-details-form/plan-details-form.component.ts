import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PlanDetails } from 'src/app/models/plan-details';
import { Term } from 'src/app/models/term';
import { TermService } from 'src/app/services/term.service';
import {PlanFeature} from 'src/app/models/plan-feature'

@Component({
  selector: 'app-plan-details-form',
  templateUrl: './plan-details-form.component.html',
  styleUrls: ['./plan-details-form.component.css']
})
export class PlanDetailsFormComponent implements OnInit {
public terms : Term[]=[];
public array_planFeaturesToAdd: PlanFeature[]=[];
public formPlanDetails: FormGroup;
  constructor(  private _TermService: TermService
    ) {
      this.formPlanDetails=new FormGroup({
        termId: new FormControl('', Validators.required),
        termValue: new FormControl('', Validators.required),
      });
     }

  ngOnInit(): void {
    this._TermService.GetAllTerms().subscribe({
      next: (data)=>{
        this.terms=data;
        console.log("terms");
        console.log(this.terms);
      }, 
      error: (error)=>{
        console.log(error);
      }
    });
  }
  addPlanFeature(){
    
    if(this.formPlanDetails.valid){
      console.log("this.formPlanDetails is true");
      const planFeature: PlanFeature={
        termName: this.getTermNameByid(this.formPlanDetails.value.termId),
        termId: this.formPlanDetails.value.termId,
        termValue: this.formPlanDetails.value.termValue
      }

      this.array_planFeaturesToAdd.push(planFeature);
      console.log(this.array_planFeaturesToAdd);
      this.resetForm();
    }
  }

  getTermNameByid(id: number):string{
    console.log("terms array");
    console.log(this.terms);
     const term=this.terms.find(term=>term.TermId==id);
    return term.TermName;
  }
  
  resetForm() {
    this.formPlanDetails.reset();
  }

}
