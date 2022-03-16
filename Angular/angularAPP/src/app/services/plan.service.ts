import { Injectable, ɵnoSideEffects } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { observeNotification } from 'rxjs/internal/Notification';
import { Plan } from '../models/plan';
import { Request } from '../models/request';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { PlanDetails } from '../models/plan-details';


@Injectable({
  providedIn: 'root'
})
export class PlanService {
  private arrayPlans:Plan[]=[];

  constructor(
    private _http: HttpClient
  ) { 
    this.arrayPlans=[
      new Plan(1, "code1", "planName1", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(2, "code2", "planName2", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(3, "code3", "planName3", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(4, "code4", "planName4", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(5, "code5", "planName5", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(6, "code6", "planName6", new Date(), new Date(), new Date(), new Date(),1,1),
      new Plan(7, "code7", "planName7", new Date(), new Date(), new Date(), new Date(),1,1), 
      
    
  ];
  }

  GetAllPlans(): Observable<any>{
   
    return this._http.get('https://localhost:44379/api/tbl_plans');
   
  }

  AddPlanToDB(body: Plan): Observable<any>{
    body.CreatedUser=1;
    body.ModifiedUser=1;
    body.ModifiedDate=new Date;
    body.CreatedDate=new Date;
   return this._http.post('https://localhost:44379/api/tbl_plans', body);
  }
}
