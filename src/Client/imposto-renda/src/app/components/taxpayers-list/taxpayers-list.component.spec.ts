import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxpayersListComponent } from './taxpayers-list.component';

describe('TaxpayersListComponent', () => {
  let component: TaxpayersListComponent;
  let fixture: ComponentFixture<TaxpayersListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaxpayersListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaxpayersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
