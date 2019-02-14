import { Injectable } from '@angular/core';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/finally';
import 'rxjs/Rx';
import { Router } from '@angular/router';
declare var $;
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/finally';



@Injectable()

export class WebserviceService {
    constructor(private http: Http) {
    }


    totalTopupAmount = 0;
    selectedTopUpamount = [];
    personalLoanList = null;

    public UpdateCarryOver: BehaviorSubject<any> = new BehaviorSubject<boolean>(false);
    getTotalCarryOverAmount(value) {
        this.UpdateCarryOver.next(value);
        this.totalTopupAmount = value;
    }

    userid = 1;

    getLoanList() {
        const headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.get('http://localhost:55869/' + this.userid + '/loans', { headers: headers })
            .map((response: Response) => response.json())
            .catch((error: any) => {
                if (error.status === 500) {
                    return Observable.throw(new Error(error.status));
                }
                else if (error.status === 400) {
                    return Observable.throw(new Error(error.status));
                }
                else if (error.status === 409) {
                    return Observable.throw(new Error(error.status));
                }
                else if (error.status === 406) {
                    return Observable.throw(new Error(error.status));
                }
                else if (error.status === 403) {
                    return Observable.throw(new Error(error.status));
                }
                else
                {
                    return Observable.throw(new Error("Error in Service!!"));
                }
            })
    }

}