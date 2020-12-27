import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild, ViewContainerRef} from '@angular/core';
import {Ticket, TicketType} from "../../model/Ticket";
import {TicketService} from "../../ticket.service";

@Component({
  selector: 'app-edit-ticket-type',
  templateUrl: './edit-ticket-type.component.html',
  styleUrls: ['./edit-ticket-type.component.css']
})
export class EditTicketTypeComponent implements OnInit {

  @Input() ticketType: TicketType
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();
  @Output() onDelete: EventEmitter<any> = new EventEmitter();

  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;

  constructor(private ticketService: TicketService) {
    this.ticketType = new TicketType()
  }

  ngOnInit() {
  }


  onSelectEditClicked() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.ticketService.updateTicketType(this.ticketType).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }

  onSelectDelete() {
    this.ticketService.deleteTicketType(this.ticketType.id).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onDelete.emit()
    })
  }
}
