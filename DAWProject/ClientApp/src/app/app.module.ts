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
import {CreateTicketComponent} from "./service-module/ticket/create-ticket/create-ticket.component";
import {ServiceModuleModule} from "./service-module/service-module.module";
import {ViewTicketsComponent} from "./service-module/ticket/view-tickets/view-tickets.component";
import {ViewTicketTypesComponent} from "./service-module/ticket-type/view-ticket-types/view-ticket-types.component";
import {ViewUserTypesComponent} from "./user-module/user-type/view-user-types/view-user-types.component";

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
    ServiceModuleModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'login-employee', component: LoginEmployeeComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'help', component: HelpComponent, canActivate: [AuthGuard] },
      { path: 'create-ticket', component: CreateTicketComponent, canActivate: [AuthGuard] },
      { path: 'view-tickets', component: ViewTicketsComponent, canActivate: [AuthGuard] },
      { path: 'view-ticket-types', component: ViewTicketTypesComponent, canActivate: [AuthGuard] },
      { path: 'view-user-types', component: ViewUserTypesComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
