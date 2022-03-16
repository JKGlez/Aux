import { TestBed } from '@angular/core/testing';

import { PlanFeatureService } from './plan-feature.service';

describe('PlanFeatureService', () => {
  let service: PlanFeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlanFeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
