import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExportDataService {


  constructor(private _http: HttpClient) { }

  ExportTable(): Observable<any>{
    return this._http.get<any>('https://localhost:44379/api/GetCSV');
  }

}

