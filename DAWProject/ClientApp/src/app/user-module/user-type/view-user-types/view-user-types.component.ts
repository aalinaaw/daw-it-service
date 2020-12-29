import {Component, OnInit} from '@angular/core';
import {UserType} from "../../model/User";
import {UserService} from "../../user.service";

@Component({
  selector: 'app-view-user-types',
  templateUrl: './view-user-types.component.html',
  styleUrls: ['./view-user-types.component.css']
})
export class ViewUserTypesComponent implements OnInit {
  userTypes: Array<UserType>;
  selectedUserType: UserType;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.loadUserTypes()
  }

  onSelectUserType(userType: UserType) {
    this.selectedUserType = userType
  }

  onEdited() {
    this.loadUserTypes()
  }

  onDeleted() {
    this.loadUserTypes()
  }

  private loadUserTypes() {
    this.userService.getUserTypes().subscribe(result => {
      this.userTypes = result
    })
  }

  onCreated() {
    this.loadUserTypes()
  }
}
