import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  getUserDetails() {
    return this.httpClient.get('http://localhost:8907/api/ManageUser');
  }

  getProjectDetails() {
    return this.httpClient.get('http://localhost:8907/api/ManageProjectMaster');
  }

  postUserDetails(userDetails: any) {
    return this.httpClient.post('http://localhost:8907/api/ManageUser', userDetails)
  }

  registerUserDetails(user: any){
    return this.httpClient.post('http://localhost:8907/api/ManageUser/insert',user)
  }
  projectRegisterDetails(userProject: any)
  {
    return this.httpClient.post('http://localhost:8907/api/ManageProjectMaster/insert',userProject)
  }
}
