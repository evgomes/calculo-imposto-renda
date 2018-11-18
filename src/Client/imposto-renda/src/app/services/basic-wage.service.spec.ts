import { TestBed, inject } from '@angular/core/testing';

import { BasicWageService } from './basic-wage.service';

describe('BasicWageService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BasicWageService]
    });
  });

  it('should be created', inject([BasicWageService], (service: BasicWageService) => {
    expect(service).toBeTruthy();
  }));
});
