import { HttpClientTestingModule,  HttpTestingController } from '@angular/common/http/testing';
import { TestBed , async} from '@angular/core/testing';

import { WebserviceService } from './webservice.service';

describe('GetLoanLists', () => {


    let service: WebserviceService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [WebserviceService],
        });
    });

    // inject the service
    service = TestBed.get(WebserviceService);
    httpMock = TestBed.get(HttpTestingController);


    it('should get the data successful', () => {
        service.getLoanList().subscribe((data: any) => {
          expect(data.length).toBeGreaterThan(1);
        });
        
        const req = httpMock.expectOne(`http://localhost:55869/1/loans`, 'LoanDetails from API');
        expect(req.request.method).toBe('GET');
    
        req.flush({
          Loans: 'LoanDetails'
        });
    
        httpMock.verify();


      });

});