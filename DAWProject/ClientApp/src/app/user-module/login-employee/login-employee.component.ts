import { Component, OnInit } from '@angular/core';
import {User} from "../model/User";
import {Router} from "@angular/router";
import {AuthService} from "../auth.service";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-login-employee',
  templateUrl: './login-employee.component.html',
  styleUrls: ['./login-employee.component.css']
})
export class LoginEmployeeComponent implements OnInit {

  user = new User()

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  onLogin() {
    console.log(this.user)
    this.authService.loginEmployee(this.user.username, this.user.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(["/"]);
        });
  }

}
