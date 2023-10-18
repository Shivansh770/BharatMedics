import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { SignupComponent } from './Components/signup/signup.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { NgxPaginationModule } from 'ngx-pagination';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { CartsComponent } from './Components/DoctorContent/carts/carts.component';
import { DashboardDoctorComponent } from './Components/DoctorContent/dashboard-doctor/dashboard-doctor.component';
import { UserOrdersComponent } from './Components/DoctorContent/user-orders/user-orders.component';
import { DrugsComponent } from './Components/drugs/drugs.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    CartsComponent,
    DashboardDoctorComponent,
    UserOrdersComponent,
    DrugsComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientTestingModule,
    NgxPaginationModule
  ],
  providers: [
  
],
  bootstrap: [AppComponent]
})
export class AppModule { }
