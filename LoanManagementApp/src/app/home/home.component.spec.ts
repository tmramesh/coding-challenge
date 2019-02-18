import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';
import { LoanTopUpComponent } from "../loan-top-up/loan-top-up.component"
import { PersonalLoanListComponent } from '../personal-loan-list/personal-loan-list.component';
import {WebserviceService} from '../webservice.service'

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeComponent,
      LoanTopUpComponent,
      PersonalLoanListComponent],
      providers: [
        { provide: WebserviceService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
  });

  it('should create HomeComponent', () => {
    expect(component).toBeTruthy();
  });
});
