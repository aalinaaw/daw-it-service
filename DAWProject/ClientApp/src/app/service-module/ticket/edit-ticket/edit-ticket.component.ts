import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {Ticket, TicketType} from "../model/Ticket";
import {TicketService} from "../ticket.service";

@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.css']
})
export class EditTicketComponent implements OnInit {

  @Input() ticket: Ticket
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();
  @Output() onDelete: EventEmitter<any> = new EventEmitter();

  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;

  constructor(private ticketService: TicketService) {
    this.ticket = new Ticket()
  }

  ngOnInit() {
  }

  onSelectEditButtonClick() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.ticketService.updateTicket(this.ticket).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }

  onSelectDelete() {
    this.ticketService.deleteTicket(this.ticket.id).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onDelete.emit()
    })
  }
}
