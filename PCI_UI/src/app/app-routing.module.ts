import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ManageProjectComponent } from './manage-project/manage-project.component';
import { ManageUserComponent } from './manage-user/manage-user.component';
import { ProfileComponent } from './profile/profile.component';
import { ProjectRegistrationComponent } from './project-registration/project-registration.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path : 'profile',
    component : ProfileComponent,
    children: [
      // {
      //   path:'',
      //   component: RegisterComponent
      // },
      {
        path: 'manage-user',
        component: ManageUserComponent,
        children: [
          {
            path : 'register',
            component : RegisterComponent
          },
        ]
      },
      {
        path: 'manage-project',
        component: ManageProjectComponent,
        children: [
          {
            path : 'register-project',
            component : ProjectRegistrationComponent,
          },    
        ]
      },
    ]
  },
  {
    path: 'reset',
    component : ResetPasswordComponent
  },

  {
    path: '**',
    redirectTo: 'login'
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
