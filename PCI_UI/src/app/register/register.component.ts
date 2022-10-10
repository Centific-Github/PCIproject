import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerDetails={
    emailID: "",
  password: "",
  userName: ""
  }
  registeredState=false;
  password = '';
  confirmPassword = '';
  isPasswordMatched: boolean = false;

  constructor(private router: Router, private loginService:LoginService) { }

  ngOnInit(): void {
  }

  onCancel(){
    this.router.navigate(['/profile'])
  }

  onPassword(pass: any) {
    this.password = pass.value;
    console.log(pass)
  }

  onConfirmPassword(pass: any) {
    this.confirmPassword = pass.value;
    if(this.password === this.confirmPassword) {
      this.isPasswordMatched = true;
    }
    console.log(this.isPasswordMatched)
  }

  onSubmit(form: NgForm) {
    // this.password = form.value.password;
    // this.confirmPassword = form.value.confirmPassword;
    let fullName = form.value.firstName + ' '+ form.value.lastName;
    this.registerDetails.emailID =  form.value.email;
    this.registerDetails.password =  form.value.password;
    this.registerDetails.userName =  fullName;
    console.log(this.registerDetails);
    this.registerUser()
    console.log(this.registerDetails.userName,'registerState');
  }

  registerUser(){
    this.loginService.registerUserDetails(this.registerDetails).subscribe((data)=>{
      if(data===1){
          this.registeredState=true
      }
      console.log(data)
    })
  }
  
}
