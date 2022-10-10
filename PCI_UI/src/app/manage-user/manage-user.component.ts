import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { LoginService } from '../login.service';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {
  usersData: any;
  p: number = 0;
  mySubscription: any;

  constructor(
    private router: Router, 
    private loginService: LoginService) 
  {
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
    this.loginService.getUserDetails().subscribe((data) => {
      this.usersData = data
      console.log(this.usersData);
    })
  }

  // ngOnDestroy(): void {
  //   // if (this.mySubscription) {
  //   //   this.mySubscription.unsubscribe();
  //   // }
  // }

}
