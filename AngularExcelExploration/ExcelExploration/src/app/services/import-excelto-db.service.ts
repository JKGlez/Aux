import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Plan } from '../model/plan';
import { PlanFeature } from '../model/plan-feature';
import { ThisReceiver } from '@angular/compiler';
import { PlanDetails } from '../model/plan-details';

import { TermService } from '../services/term.service';
import { Term } from '../model/term';

@Injectable({
  providedIn: 'root',
})
export class ImportExceltoDBService {

  public array_PlansToImport: Plan[] = [];

  public array_RefTermsAtDB: Term[] = [];



  constructor(private http: HttpClient, private _termService: TermService) {
    this._termService.GetAllTerms().subscribe(
      {
        next:(Terms) => {
          this.array_RefTermsAtDB = Terms;
        },
        error:(error) => {
          console.log(error);
        }
      }
    );

  }

  importExcelToDB(rawDataCSV: any): any {
    const string_ApiMethod: string = 'https://localhost:44379/api/PlanTerms';

    var array_splitRawDataCSV = rawDataCSV.split('\\n');

    for (let i = 1; i < array_splitRawDataCSV.length - 1; i++) {
      var splitDataPerRow = array_splitRawDataCSV[i].split('\\t');

      var currentPlanCode = splitDataPerRow[0];
      var currentPlanName = splitDataPerRow[1];
      var currentEffectiveFromDate = new Date(splitDataPerRow[2]);
      var currentEffectiveTillDate = new Date(splitDataPerRow[3]);
      var currentCreatedDate = new Date();
      var currentModifiedDate = new Date();
      var currentCreatedUser = this.getCurrentUser();
      var currentModifiedUser = this.getCurrentUser();

      var array_CurrentPlanFeatures : PlanFeature[] = [
        new PlanFeature("Actuary",splitDataPerRow[4],-1),
        new PlanFeature("Annuity",splitDataPerRow[5],-1),
        new PlanFeature("Claim",splitDataPerRow[6],-1),
        new PlanFeature("Coverage",splitDataPerRow[7],-1),
        new PlanFeature("Death Benefit",splitDataPerRow[8],-1),
        new PlanFeature("Deductible",splitDataPerRow[9],-1),
        new PlanFeature("Exclusion",splitDataPerRow[10],-1),
        new PlanFeature("Lapse",splitDataPerRow[11],-1),
        new PlanFeature("Peril",splitDataPerRow[12],-1),
        new PlanFeature("Renewal",splitDataPerRow[13],-1)
        ];

        array_CurrentPlanFeatures.forEach(planFeature => {
          const ter = this.getTermForEachPlanDetail(planFeature);
        });

      var tbl_planDetails: PlanDetails[]=[];

      let obj_CurrentPlan : Plan = new Plan(
        -1,
        currentPlanCode,
        currentPlanName,
        currentEffectiveFromDate,
        currentEffectiveTillDate,
        currentCreatedDate,
        currentModifiedDate,
        currentCreatedUser,
        currentCreatedUser,
        tbl_planDetails);

        array_CurrentPlanFeatures.forEach(planFeature => {
          obj_CurrentPlan.tbl_planDetails.push(this.createNewPlanDetailUsingFeature(planFeature,obj_CurrentPlan));
        });

      this.array_PlansToImport.push(obj_CurrentPlan)
    }

    console.log("array_PlansToImport:");
    console.log(this.array_PlansToImport);

    this.http.post<any>(string_ApiMethod, this.array_PlansToImport ).subscribe(arg => {
    });


  }

  createNewPlanDetailUsingFeature(feature: PlanFeature, plan: Plan): PlanDetails {

    const obj_PlanDetails: PlanDetails = {
      PlanDetailsId: -1,
      PlanId: plan.PlanId,
      TermId: feature.Termid,
      TermValue: feature.TermValue,
      CreatedDate: new Date(),
      ModifiedDate: new Date(),
      CreatedUser: this.getCurrentUser(),
      ModifiedUser: this.getCurrentUser(),
      tbl_refterms: null
    }
    return obj_PlanDetails;
  }

  getCurrentUser():number{
    return 1;
  }

  getTermForEachPlanDetail(planFeature:PlanFeature):PlanFeature{
    let term = this.array_RefTermsAtDB.find(t => t.TermName == planFeature.TermName);
    if(term)
      planFeature.Termid=term?.TermId;
    return planFeature;
  }

  getTermById(id:number):Term{

    let termNumber:number = this.array_RefTermsAtDB.findIndex(t => t.TermId == id);

    return this.array_RefTermsAtDB[termNumber];

  }
}
