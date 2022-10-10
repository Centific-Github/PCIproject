import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms'

import { LoginService } from '../login.service';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  inputValue:string = '';
  inputPassword:string = '';
  loginState: boolean = false;
  isLoggedin: boolean = false;
  savedUserDetails: any;

  userDetails = {
    emailID: '',
    password:''
  }
  
  
  onInput(a: any){
    this.inputValue = a.target.value
    // console.log(this.inputValue)
  }
  oninputPassword(a: any){
    this.inputPassword = a.target.value
    // console.log(this.inputPassword)
  }
  constructor(private router: Router,private loginService: LoginService) { }

  ngOnInit(): void {
    
  }

  onSubmit(form: NgForm) {
    // this.isLoggedin = true;
    this.userDetails = form.value;
    console.log(form);
    this.postDetails()
  }

  postDetails() {
    this.loginService.postUserDetails(this.userDetails).subscribe((data) => {
      this.savedUserDetails = data;
      var username = this.savedUserDetails;
      if(this.savedUserDetails===null){
         this.loginState=true;
         return;
      }else{
        this.router.navigate(['/profile']
        // {queryParams:
        // {data:this.savedUserDetails.userName}}
        )
      }

      console.log(this.savedUserDetails.userName,'loginState');
    })
  }
 

  onReset() {
    this.router.navigate(['/reset'])
  }
  
  

}
