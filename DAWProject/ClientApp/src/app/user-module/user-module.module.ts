import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HelpComponent } from './help/help.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {RegisterService} from "./register.service";
import {UserService} from "./user.service";
import { LoginEmployeeComponent } from './login-employee/login-employee.component';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, HelpComponent, LoginEmployeeComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [RegisterService, UserService],
  exports: [LoginComponent, RegisterComponent, HelpComponent, LoginEmployeeComponent]
})
export class UserModuleModule { }
