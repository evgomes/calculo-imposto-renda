import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicWageBadgeComponent } from './basic-wage-badge.component';

describe('BasicWageBadgeComponent', () => {
  let component: BasicWageBadgeComponent;
  let fixture: ComponentFixture<BasicWageBadgeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BasicWageBadgeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BasicWageBadgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
