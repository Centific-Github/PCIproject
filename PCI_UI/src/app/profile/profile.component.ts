import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userName: any;
  // isManageUserActive: boolean = false;
  // isManageProjectActive: boolean = false;

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  // onManageUser() {
  //   this.isManageUserActive = true;
  //   this.isManageProjectActive = false;
  // }

  // onManageProject() {
  //   this.isManageProjectActive = true;
  //   this.isManageUserActive = false;
  // }

  onLogout(){
    this.router.navigate(['/login'])
  }
}
