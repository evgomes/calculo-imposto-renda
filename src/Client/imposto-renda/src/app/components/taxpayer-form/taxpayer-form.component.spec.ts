import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxpayerFormComponent } from './taxpayer-form.component';

describe('TaxpayerFormComponent', () => {
  let component: TaxpayerFormComponent;
  let fixture: ComponentFixture<TaxpayerFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaxpayerFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaxpayerFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
