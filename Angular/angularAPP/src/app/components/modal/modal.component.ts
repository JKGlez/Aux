import { Component, Input, OnInit } from '@angular/core';
import { Term } from 'src/app/models/term';
import { TermService } from 'src/app/services/term.service';
@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
 @Input () planCode: string;
 public terms: any[]; 

  constructor(private _termService: TermService) { }

  ngOnInit() {
   
  }
  ngOnChanges(){
    if(this.planCode){
      this._termService.GetPlanFeaturesByPlanCode(this.planCode).subscribe({
        next:(data)=>{
          this.terms=data;
          console.log(this.terms);
        },
        error: (error)=>{
          console.log(error);
        }
      });
    }
  }

  clearCode(){
    this.planCode=null;
    this.terms=null;
  }


}



