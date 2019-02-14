import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalLoanListComponent } from './personal-loan-list.component';

describe('PersonalLoanListComponent', () => {
  let component: PersonalLoanListComponent;
  let fixture: ComponentFixture<PersonalLoanListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonalLoanListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalLoanListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
