import {Component, ElementRef, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {UserType} from "../../model/User";
import {UserService} from "../../user.service";

@Component({
  selector: 'app-create-user-type',
  templateUrl: './create-user-type.component.html',
  styleUrls: ['./create-user-type.component.css']
})
export class CreateUserTypeComponent implements OnInit {

  userType: UserType

  // @ts-ignore
  @ViewChild("closeButton") closeButton: ElementRef;
  @Output() onCreate: EventEmitter<any> = new EventEmitter();

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userType = new UserType()
  }

  onCreateSelected() {
    this.userService.createUserType(this.userType).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onCreate.emit()
    })
  }
}
