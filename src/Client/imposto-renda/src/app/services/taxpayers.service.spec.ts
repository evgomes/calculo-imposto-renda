import { TestBed, inject } from '@angular/core/testing';

import { TaxpayersService } from './taxpayers.service';

describe('TaxpayersService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TaxpayersService]
    });
  });

  it('should be created', inject([TaxpayersService], (service: TaxpayersService) => {
    expect(service).toBeTruthy();
  }));
});
