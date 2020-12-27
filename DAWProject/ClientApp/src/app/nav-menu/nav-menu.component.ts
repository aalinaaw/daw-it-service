import {Component, OnInit} from '@angular/core';
import {AuthService} from "../user-module/auth.service";
import {Router} from "@angular/router";
import {User} from "../user-module/model/User";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  username = "";
  showForUser = false;
  showForEmployee = false;
  showLoginForUser = true;
  showLoginForEmployee = true;
  showRegister = true;

  constructor(private authService: AuthService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.authService.currentEmployee.subscribe(result => {
      if (result != null) {
        this.username = result.username
        this.showForEmployee = true
        this.showForUser = false
        this.showLoginForUser = false
        this.showLoginForEmployee = false
        this.showRegister = false
      } else {
        this.username = ""
        this.showForEmployee = false
        this.showForUser = false
        this.showLoginForUser = true
        this.showLoginForEmployee = true
        this.showRegister = true
      }
    })
    this.authService.currentUser.subscribe(result => {
      if (result != null) {
        this.username = result.username
        this.showForEmployee = false
        this.showForUser = true
        this.showLoginForUser = false
        this.showLoginForEmployee = false
        this.showRegister = false
      } else {
        this.username = ""
        this.showForEmployee = false
        this.showForUser = false
        this.showLoginForUser = true
        this.showLoginForEmployee = true
        this.showRegister = true
      }
    })
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

  onLogoutEmployee() {
    this.authService.logoutEmployee();
    this.router.navigate(["login-employee"])
  }
}
