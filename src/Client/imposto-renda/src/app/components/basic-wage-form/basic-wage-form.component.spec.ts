import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicWageFormComponent } from './basic-wage-form.component';

describe('BasicWageFormComponent', () => {
  let component: BasicWageFormComponent;
  let fixture: ComponentFixture<BasicWageFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BasicWageFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BasicWageFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
