import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../helpers/validateForm';
import { NgToastService } from 'ng-angular-popup';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
 
  type:string = "password";
  isText: boolean = false;
  eyeIcon : string = "fa-eye-slash"
  loginForm!: FormGroup;
 

  constructor(private fb: FormBuilder, private auth : AuthenticationService, private router : Router, private toast:NgToastService){}
  
ngOnInit():void{
  this.loginForm = this.fb.group({
    username: ['',Validators.required],
    password: ['', Validators.required]
  })

}

hideShowPass(){
  this.isText = !this.isText;
  this.isText? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
  this.isText? this.type = "text" : this.type = "password";

}

onLogin(){
  if(this.loginForm.valid){

    this.auth.login(this.loginForm.value).subscribe({
      next:(res)=>{
        this.loginForm.reset();
        this.toast.success({detail:"Success", summary:res.message,duration:5000});
        this.router.navigate(['nav'])
      },
      error:(err)=>{
        
        this.toast.error({detail:"ERROR", summary:"something seems wrong!",duration:5000});
          
        
      }
    })

  }else{
    ValidateForm.validateAllFormFields(this.loginForm);
  }
}
  
}
