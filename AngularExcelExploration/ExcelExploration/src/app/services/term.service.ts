import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Subscriber } from 'rxjs';
import { Observable } from 'rxjs';
import { PlanFeature } from '../model/plan-feature';
import { Term } from '../model/term';

@Injectable({
  providedIn: 'root'
})
export class TermService {

  private arrayTerms: Term[]=[];
  constructor(
    private _http: HttpClient
  ) {
    this.arrayTerms=[
      new Term(1, "term1", "Description1"),
      new Term(2, "term2", "Description2"),
    ];
  }

  GetAllTerms(): Observable<Term[]>{
    return this._http.get<Term[]>('https://localhost:44379/api/tbl_refterms');
  }


  GetPlanFeaturesByPlanCode(planCode: string): Observable<PlanFeature[]>{
      return this._http.get<PlanFeature[]>('https://localhost:44379/api/getPlanFeatures', {params: {"code": planCode}});
  }
}
