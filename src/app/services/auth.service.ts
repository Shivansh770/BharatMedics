import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgToastComponent, NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userPayload : any;

  private baseUrl : string ="https://localhost:7004/api/User/";
  constructor(private http : HttpClient , private route : Router , public toast : NgToastService ) {
    this.userPayload = this.decodedToken();
   }

   SignUp(UserObj:object){
    return this.http.post<any>(`${this.baseUrl}SignUp`,UserObj);

  }

  Login(LoginObj : object){
    return this.http.post<any>(`${this.baseUrl}Login`,LoginObj);
  }

  decodedToken(){
    const jwtHelper = new JwtHelperService();
   const token = this.getToken();
   var nex = <string>token;

    return jwtHelper.decodeToken(nex);
 }

 getToken() {
  

  return localStorage.getItem('token')
}


  jwtHelperService = new JwtHelperService();

  

}
