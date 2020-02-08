import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BsSharedModule } from '../../shared/bs-shared.module';
import { LoginComponent } from './login.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent
  }
];

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    BsSharedModule
  ]
})
export class LoginModule { }
