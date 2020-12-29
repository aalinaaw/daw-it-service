import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {UserType} from "../../model/User";
import {UserService} from "../../user.service";

@Component({
  selector: 'app-edit-user-type',
  templateUrl: './edit-user-type.component.html',
  styleUrls: ['./edit-user-type.component.css']
})
export class EditUserTypeComponent implements OnInit {

  @Input() userType: UserType
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();
  @Output() onDelete: EventEmitter<any> = new EventEmitter();

  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;

  constructor(private userService: UserService) {
    this.userType = new UserType()
  }

  ngOnInit() {
  }


  onSelectEditClicked() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.userService.updateUserType(this.userType).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }

  onSelectDelete() {
    this.userService.deleteUserType(this.userType.id).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onDelete.emit()
    })
  }
}
