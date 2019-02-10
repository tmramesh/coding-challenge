import { Component, OnInit } from '@angular/core';
import{WebserviceService} from '../webservice.service'

@Component({
  selector: 'app-loan-top-up',
  templateUrl: './loan-top-up.component.html',
  styleUrls: ['./loan-top-up.component.css']
})
export class LoanTopUpComponent implements OnInit {

  constructor(private getdata:WebserviceService) { }


  ngOnInit() {

  }

getTotalAmount(){
 return this.getdata.totalTopupAmount;
}


/**add new personalloan btn enable*/
getnewloanActive(){
  if(this.getdata.selectedTopUpamount.length<3 && this.getdata.selectedTopUpamount.length>=0){
    return true;
    }
    else{
      return false;
    }
}

}
