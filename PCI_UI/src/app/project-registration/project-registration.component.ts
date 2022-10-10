import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-project-registration',
  templateUrl: './project-registration.component.html',
  styleUrls: ['./project-registration.component.css']
})
export class ProjectRegistrationComponent implements OnInit {
  projectRegisterDetails = {
    projectCode: "",
    projectManager: ""
  }
  registeredState = false;

  constructor(private loginService:LoginService, private router: Router) { }

  ngOnInit(): void {
  }

  onCancel(){
    this.router.navigate(['/profile'])
  }

  onProjectRegister(form: any) {
    this.projectRegisterDetails.projectCode = form.value.projectCode;
    this.projectRegisterDetails.projectManager = form.value.projectManager;
    console.log(this.projectRegisterDetails);
    this.projectRegisterDetailService()
  }

  projectRegisterDetailService(){
   this.loginService.projectRegisterDetails(this.projectRegisterDetails).subscribe((data)=>{
    if(data === 1) {
      this.registeredState = true;
    }
   })
  }

}
