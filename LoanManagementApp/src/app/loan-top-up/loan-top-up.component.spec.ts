import { async, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
import { LoanTopUpComponent } from './loan-top-up.component';
import { WebserviceService } from '../webservice.service'
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('LoanTopUpComponent', () => {

  let component: LoanTopUpComponent;
  let fixture: ComponentFixture<LoanTopUpComponent>;
  let webService: WebserviceService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [LoanTopUpComponent],
      providers: [
        { provide: WebserviceService }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanTopUpComponent);
    component = fixture.componentInstance;
  });

  it('should create LoanTopUpComponent', () => {
    expect(component).toBeTruthy();
  });

  it('Mock/Spy Get TotalAmount ', () => {
    spyOn(component, 'getTotalAmount').and.returnValue(0);
    expect(component.getTotalAmount()).toBe(0);
  });

  it('Mock/Spy New Loan Status', () => {
    spyOn(component, 'getnewloanActive').and.returnValue("true");
    expect(component.getnewloanActive()).toBeTruthy();
  });
});