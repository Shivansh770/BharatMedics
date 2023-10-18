import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  p=1;
  public role! : string
 fullName :string = ""
  public user : any =[]
  constructor(private auth : AuthService , private api : ApiService,private route : Router ,
     private userStore : UserService){

  }
  ngOnInit(): void {
    this.api.getUsers()
    .subscribe(res=>{
    this.user = res;
    })

    this.userStore.getFullNameFromStore()
    .subscribe(val=>{
      let fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = val || fullNameFromToken
    })

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      let roleFromToken = this.auth.getRoleFromToken();
      this.role=val || roleFromToken

    })
    
  }

  logout(){
    console.log("logout has been called")
    this.route.navigate(['']);
    this.auth.Logout();
    

  }
}
  
