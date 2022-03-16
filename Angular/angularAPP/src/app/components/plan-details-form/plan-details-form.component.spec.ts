import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanDetailsFormComponent } from './plan-details-form.component';

describe('PlanDetailsFormComponent', () => {
  let component: PlanDetailsFormComponent;
  let fixture: ComponentFixture<PlanDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanDetailsFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
