import {Component, OnInit} from '@angular/core';
import {AuthService} from "../user-module/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  username = "";

  constructor(private authService: AuthService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.authService.currentEmployee.subscribe(result => {
      this.username = result != null ? result.username : this.username
    })
    this.authService.currentUser.subscribe(result => {
      this.username = result != null ? result.username : this.username
    })
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogout() {
    this.username = "";
    this.authService.logout();
    this.router.navigate(["login"])
  }

  isUserLoggedIn() {
    return this.authService.currentUserValue != null
  }

  isEmployeeLoggedIn() {
    return this.authService.currentEmployeeValue != null
  }

  onLogoutEmployee() {
    this.username = "";
    this.authService.logoutEmployee();
    this.router.navigate(["login-employee"])
  }
}
