// import { Component, OnInit} from '@angular/core';
// import { FormControl, FormGroup, Validators } from '@angular/forms';
// import { AuthService } from 'src/app/services/auth.service';


// @Component({
//   selector: 'app-signup',
//   templateUrl: './signup.component.html',
//   styleUrls: ['./signup.component.css']
// })
// export class SignupComponent implements OnInit {
//   displayMsg : string ='';
//   isAccountCreated : boolean = false;

//   constructor(private authservice: AuthService) { }
//   ngOnInit(): void {   
//   }

//   registerForm = new FormGroup({
//     Name: new FormControl('', [Validators.required,Validators.pattern('[a-zA-Z].*')]),
//     email: new FormControl('',[Validators.required,Validators.email]),
//     password: new FormControl('',[Validators.required,Validators.minLength(6),Validators.maxLength(15)])
//   });

//   registerSubmitted() {
//     console.log("Submited");
//     this.authservice.registerUser([
//       this.registerForm.value.Name ,
//       this.registerForm.value.email,
//       this.registerForm.value.password
//     ])
//     .subscribe((res: string) =>{
//       if(res == 'User registered successfully.'){
//         this.displayMsg ='Account Created Successfuly!';
//         this.isAccountCreated = true;
//       }else if(res == 'User already exists.'){
//         this.displayMsg = 'Account already exists.';
//         this.isAccountCreated = false;
//       }else {
//         this.displayMsg = 'Something went Wrong.';
//         this.isAccountCreated = false;
//       }
//        console.log(res);
//     })
//   }

//   get Name() : FormControl{
//     return this.registerForm.get("Name") as FormControl;
//   }
//   get Email() : FormControl{
//     return this.registerForm.get("email") as FormControl;
//   }
  
//   get Password() : FormControl{
//     return this.registerForm.get("password") as FormControl;
//   }
  
// }

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastModule, NgToastService } from 'ng-angular-popup';
import validateform from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  
})
export class SignupComponent  implements OnInit {
  registerForm : FormGroup;
  temp: string ;

constructor(private fb : FormBuilder , private auth : AuthService , private router : Router
  ,private Toast : NgToastService){

}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username :['',Validators.required],
      password :['',Validators.required],
      name :['',Validators.required],
      email :['',Validators.required]
    })
    
  }

  OnSubmit(){
    if(this.registerForm.valid){
      this.auth.SignUp(this.registerForm.value)
        .subscribe({
                next:(res=>{
             
                  this.Toast.success({detail:"Success", summary : res.message , duration:3500});
            
            this.registerForm.reset();
            console.log(res.status);
            
             this.router.navigate(['login']);
          })
        ,error:(err=>{
          console.log(err);
          
          this.temp=err.error.message;
      
   
     console.log(this.temp);
        
          this.Toast.error({detail:"Error", summary :this.temp, duration:3500});
          
        })


      })
    
      console.log(this.registerForm.value);
      console.log("kam kia yha tak");
      
    }
    else {
            console.log("Not Working");
            validateform.ValidateAllFormFeilds(this.registerForm);
            alert("Invalid Details.");

            
    }

  }

  

}

