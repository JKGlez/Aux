import { Component, OnInit, Output, EventEmitter, Input, OnChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PlanService } from 'src/app/services/plan.service';
import { Request } from 'src/app/models/request';
import { Plan } from 'src/app/models/plan';
import { HighlightSpanKind } from 'typescript';
import { ExportDataService } from 'src/app/services/export-data.service';


@Component({
  selector: 'app-plan-form',
  templateUrl: './plan-form.component.html',
  styleUrls: ['./plan-form.component.css']
})
export class PlanFormComponent implements OnInit, OnChanges {

  @Output () event_onPlanAdded: EventEmitter<number>= new EventEmitter();
  @Input () plan: Plan;
  @Input () operation: string;
  @Output () onCancel
 public planForm: FormGroup;

 
  constructor(private _planService: PlanService, private _exportService: ExportDataService) {     
    this.planForm = new FormGroup({
      planCode: new FormControl('', Validators.required),
      planName: new FormControl('', Validators.required),
      effectiveFromDate: new FormControl('', Validators.required),
      effectiveTillDate: new FormControl('', Validators.required),
    });
   
  }
  
  
  updateProfile() {
   
    
  }
  
ngOnInit(): void {
  this.updateProfile();
}
ngOnChanges(){
  if(this.operation=="edit"){
    this.planForm.patchValue({
      planCode: this.plan.PlanCode,
      planName: this.plan.PlanName,
      effectiveFromDate: this.formatDate(this.plan.EffectiveFromDate),
      effectiveTillDate:this.formatDate(this.plan.EffectiveTillDate)
      
    });
  }else{
    this.planForm.patchValue({
      planCode:'',
      planName: '',
      effectiveFromDate: '',
      effectiveTillDate: ''
      
    });
  }
}


private formatDate(date) {
  const d = new Date(date);
  let month = '' + (d.getMonth() + 1);
  let day = '' + d.getDate();
  const year = d.getFullYear();
  if (month.length < 2) month = '0' + month;
  if (day.length < 2) day = '0' + day;
  return [year, month, day].join('-');
}



  saveToDB(){
    if(this.operation=="edit"){
      
    }
    if(this.operation=="add"){
      this.addPlan();
    }
     
    
  }

  saveToExcel(){
    this._exportService.ExportTable().subscribe({
      next:()=>{
        console.log("saving to excel");
      }, 
      error: (error)=>{
        console.log(error);
      },
      complete:()=>{
        alert("The data was downloaded successfully");
      }
    });
  }

  saveTheForm(){
    alert("The form was saved");
    console.log("saving the form to Excel");
  }

  addPlan(){
    console.log("planForm value");
    console.log(this.planForm.value);
    
    this._planService.AddPlanToDB(this.planForm.value).subscribe({
      next: (response)=>{
        console.log(response);
      }, 
      error: (error)=>{
        console.log(error);
      }, 
      complete: ()=>{
        this.event_onPlanAdded.emit();
        this.planForm.reset();
      }
      
    });
  }

 
  createRequest(obj_formValue: any): Request{
    const request: Request={
      plan: {
        PlanId: -1,
        PlanCode: obj_formValue.planCode,
        PlanName:obj_formValue.planName,
        EffectiveFromDate:obj_formValue.effectiveFromDate,
        EffectiveTillDate: obj_formValue.effectiveTillDate,
        CreatedDate:null,
        ModifiedDate:null,
        CreatedUser:1,
        ModifiedUser:1,
      }, 
      planDetails: {
        PlanDetailsId: -1,
        PlanId:-1,
        TermId:-1,
        TermValue:obj_formValue.termValue,
        CreatedDate:null,
        ModifiedDate:null,
        CreatedUser: 1,
        ModifiedUser:1
      }, 
      term: {
        TermId:-1,
        TermName:obj_formValue.termName,
        TermDescription:obj_formValue.TermDescription
      }
    }
    return request;
    }
  }


