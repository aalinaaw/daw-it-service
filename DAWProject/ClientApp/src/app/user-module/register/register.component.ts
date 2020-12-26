import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {RegisterService} from "../register.service";
import {User, UserType} from "../model/User";
import {UserService} from "../user.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: User = new User()
  userTypes = Array<UserType>();
  selectedUserType: UserType;

  constructor(private router: Router, private registerService: RegisterService, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserTypes().subscribe(result => {
      this.userTypes = result;
      this.user.userType = this.userTypes[0];
    });
  }

  onRegister() {
    this.registerService.registerUser(this.user).subscribe(_ => {
      this.router.navigate(["/"]);
    })
  }

  onSelectUserType(userType: UserType) {
    this.user.userType = userType;
  }
}
