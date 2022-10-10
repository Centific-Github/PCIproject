import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-manage-project',
  templateUrl: './manage-project.component.html',
  styleUrls: ['./manage-project.component.css']
})
export class ManageProjectComponent implements OnInit {

  projectDetails: any;
  p: number = 1;
  mySubscription: any;

  constructor( 
    private loginService: LoginService, 
    private router:Router) { 
      this.router.routeReuseStrategy.shouldReuseRoute = () => {
        return false;
      };
      // this.mySubscription = this.router.events.subscribe((event) => {
      //   if (event instanceof NavigationEnd) {
      //     this.router.navigated = false;
      //   }
      // });
    }

  ngOnInit(): void {
    this.loginService.getProjectDetails().subscribe((data) => {
      this.projectDetails = data;
      console.log(data);
    })
  }

  // ngOnDestroy(): void {
  //   // if (this.mySubscription) {
  //   //   this.mySubscription.unsubscribe();
  //   // }
  // }

}
