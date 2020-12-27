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
import { HighlightDirective } from './highlight.directive';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, HelpComponent, LoginEmployeeComponent, HighlightDirective],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [RegisterService, UserService],
    exports: [LoginComponent, RegisterComponent, HelpComponent, LoginEmployeeComponent, HighlightDirective]
})
export class UserModuleModule { }
