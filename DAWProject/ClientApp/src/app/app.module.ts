import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {LoginComponent} from "./user-module/login/login.component";
import {UserModuleModule} from "./user-module/user-module.module";
import {RegisterComponent} from "./user-module/register/register.component";
import {HelpComponent} from "./user-module/help/help.component";
import {LoginEmployeeComponent} from "./user-module/login-employee/login-employee.component";
import {JwtInterceptor} from "./user-module/jwt.interceptor";
import {ErrorInterceptor} from "./user-module/error.interceptor";
import {AuthGuard} from "./user-module/auth.guard";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    UserModuleModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'login-employee', component: LoginEmployeeComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'help', component: HelpComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
