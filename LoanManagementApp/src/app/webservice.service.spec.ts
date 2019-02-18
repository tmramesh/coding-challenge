import {
  HttpClientTestingModule,
  HttpTestingController
} from "@angular/common/http/testing";
import { TestBed, fakeAsync, tick } from "@angular/core/testing";
import { HttpModule } from '@angular/http';
import { WebserviceService } from "./webservice.service";
import { HttpClient } from "@angular/common/http";

describe("WebserviceService: getLoanList", () => {
  let service: WebserviceService;
  let httpTestingController: HttpTestingController;
  let httpMock: HttpTestingController;

  beforeEach(() => {
      TestBed.configureTestingModule({
          imports: [HttpClientTestingModule, HttpModule],
          providers: [WebserviceService]
      });
      // Returns a service with the MockBackend so we can test with dummy responses
      service = TestBed.get(WebserviceService);

      // Inject the http service and test controller for each test
      httpTestingController = TestBed.get(HttpTestingController);
  });
 
  it('should create', () => {
    expect(service).toBeTruthy();
  });

  it('should get the data successful', () => {
    service.getLoanList().subscribe((data: any) => {
      expect(data.length).toBeGreaterThan(1);
    });
  });
     
  it('should return an Observable<Loan[]>', () => {
    const dummyLoans: any = [
      {
        Balance: 200,
        EarlyPaymentFee: "123",
        Interest: "12",
        LoanID: "1",
        LoanName :"Loan 1",
        PayOutCarryOver: "22",
        UserName :"Ramesh"
      },
      {
        Balance: 220,
        EarlyPaymentFee: "200",
        Interest: "20",
        LoanID: "2",
        LoanName :"Loan 2",
        PayOutCarryOver: "10",
        UserName :"Ramesh"
      }
  ];

    service.getLoanList().subscribe(data => {
       expect(data).toEqual(dummyLoans);
    });
 
  });
   
});

