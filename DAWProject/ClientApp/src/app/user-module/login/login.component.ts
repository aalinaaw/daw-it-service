import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from "../auth.service";
import {User} from "../model/User";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user = new User()

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  onLogin() {
    this.authService.loginUser(this.user.username, this.user.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(["/"]);
        });
  }
}
