import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxpayersViewComponent } from './taxpayers-view.component';

describe('TaxpayersViewComponent', () => {
  let component: TaxpayersViewComponent;
  let fixture: ComponentFixture<TaxpayersViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaxpayersViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaxpayersViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
