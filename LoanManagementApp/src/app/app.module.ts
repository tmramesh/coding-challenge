import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { WebserviceService } from './webservice.service';
import { HomeComponent } from './home/home.component';
import { LoanTopUpComponent } from './loan-top-up/loan-top-up.component';
import { PersonalLoanListComponent } from './personal-loan-list/personal-loan-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoanTopUpComponent,
    PersonalLoanListComponent,
  ],
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    HttpModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [WebserviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
