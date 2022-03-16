import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PlanFeatureService {

  constructor(
    private _http: HttpClient
  ) { }

  getPlanFeaturesByPlanCode(planCode: string){
    return this._http.get('https://localhost:44379/api/getPlanFeatures', {params: {"id": planCode}});
  }
}
