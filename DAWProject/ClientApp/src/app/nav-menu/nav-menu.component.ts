import { Component } from '@angular/core';
import {AuthService} from "../user-module/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authService: AuthService,
              private router: Router) {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogout() {
    this.authService.logout();
    this.router.navigate(["login"])
  }

  isUserLoggedIn() {
    return this.authService.currentUserValue != null
  }

  isEmployeeLoggedIn(){
    return this.authService.currentEmployeeValue != null
  }

  onLogoutEmployee() {
      this.authService.logoutEmployee();
      this.router.navigate(["login-employee"])
  }
}
