import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GridComponent } from './components/grid/grid.component';
import { PlanFormComponent } from './components/plan-form/plan-form.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './components/modal/modal.component';
import { HttpClientModule } from '@angular/common/http';
import { EditModalComponent } from './components/edit-modal/edit-modal.component';
import { PlanDetailsFormComponent } from './components/plan-details-form/plan-details-form.component';


@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    PlanFormComponent,
    ModalComponent,
    EditModalComponent,
    PlanDetailsFormComponent,
  ],
  imports: [
    FormsModule,
  ReactiveFormsModule,
  HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule, 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
