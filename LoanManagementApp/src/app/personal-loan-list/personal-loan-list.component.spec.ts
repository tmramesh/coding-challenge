import { async, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
import { PersonalLoanListComponent } from './personal-loan-list.component';
import { WebserviceService } from '../webservice.service'
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('PersonalLoanListComponent', () => {

  let component: PersonalLoanListComponent;
  let fixture: ComponentFixture<PersonalLoanListComponent>;
  let webService: WebserviceService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [PersonalLoanListComponent],
      providers: [
        { provide: WebserviceService }
      ]
    })
      .compileComponents();

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalLoanListComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Spy On Get LoanList 1 ', () => {
    spyOn(component, 'selectTopupCheckbox').and.returnValue('Loan List');
    
    expect(component.selectTopupCheckbox()).toBe('Loan List');
  });
});



