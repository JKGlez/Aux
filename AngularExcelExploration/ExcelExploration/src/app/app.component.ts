import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';

import * as XLSX from 'xlsx';
import { ImportExceltoDBService } from './services/import-excelto-db.service';
// import * as fs from 'fs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ExcelExploration';
  rawDataCSV!: string;
  data:any;

  csvContent!: string;

  constructor(
    @Inject(DOCUMENT) private _document: any,
    private ImportExceltoDBService : ImportExceltoDBService
  ) {}

  fileUpload(event:any){
    //console.log(event.target.files);
    const selectedFile = event.target.files[0];
    //console.log(selectedFile);

    // var lines = selectedFile.split("\n");

    // console.log(lines);

    // var result = [];

    // var headers = lines[0].split(",");


    //const data = fs.readFileSync(selectedFile,{encoding: 'utf-8'});

    //console.log(data);

     const fileReader = new FileReader();
     fileReader.readAsBinaryString(selectedFile);

    //  this.csvContent = selectedFile;

    //  console.log(this.csvContent);


    //  //console.log(fileReader);
    fileReader.onload = (event:any) => {
      //console.log(event);
      let binaryData = event.target.result;
      let workbook = XLSX.read(binaryData,{type:'binary'});
      workbook.SheetNames.forEach(sheet =>{
        this.data = XLSX.utils.sheet_to_txt(workbook.Sheets[sheet]);
        //console.log(this.data)
        this.rawDataCSV = JSON.stringify(this.data, undefined, 4);
      })
      //console.log(this.rawDataCSV);
      this.ImportExceltoDBService.importExcelToDB(this.rawDataCSV);
    }
  }




}
