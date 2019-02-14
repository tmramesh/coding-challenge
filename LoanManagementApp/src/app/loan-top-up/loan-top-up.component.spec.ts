import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanTopUpComponent } from './loan-top-up.component';

describe('LoanTopUpComponent', () => {
  let component: LoanTopUpComponent;
  let fixture: ComponentFixture<LoanTopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoanTopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanTopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
