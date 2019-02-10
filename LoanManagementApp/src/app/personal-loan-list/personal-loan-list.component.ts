import { Component, OnInit } from '@angular/core';
import { WebserviceService } from '../webservice.service'
declare var $: any;

@Component({
  selector: 'app-personal-loan-list',
  templateUrl: './personal-loan-list.component.html',
  styleUrls: ['./personal-loan-list.component.css']
})
export class PersonalLoanListComponent implements OnInit {
  totalamount = 0;

  constructor(private getdata: WebserviceService) {
  }

  
  ngOnInit() {
    this.getloanlist();
  }
  singleCheckArray = [];
  selectTopupCheckbox() {

    this.singleCheckArray = $('.singleselect:checkbox:checked').map(function () {
      var getdata = this.value;
      return getdata;
    }).get();
    this.getdata.selectedTopUpamount = this.singleCheckArray;


    this.totalamount = 0;

    for (var i = 0; i < this.singleCheckArray.length; i++) {
      this.totalamount = this.totalamount + Number(this.singleCheckArray[i]);
    }
    this.getdata.getTotalCarryOverAmount(this.totalamount);
  }
  loanlist = [];
  getloanlist() {
    return this.getdata.getLoanList()
      .subscribe(data => {
        console.log(data)
        this.loanlist = data
      },
        Error => {
          alert(Error)
        });
  }
  showOnCheck(amount) {

    var value = (amount).toString();

    if (this.singleCheckArray.indexOf(value) != -1) {
      return true;
    }
    else {
      return false;
    }
  }
}
