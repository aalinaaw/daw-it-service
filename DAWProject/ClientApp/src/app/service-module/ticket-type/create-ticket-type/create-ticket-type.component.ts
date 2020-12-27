import {Component, ElementRef, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {TicketType} from "../../model/Ticket";
import {TicketService} from "../../ticket.service";

@Component({
  selector: 'app-create-ticket-type',
  templateUrl: './create-ticket-type.component.html',
  styleUrls: ['./create-ticket-type.component.css']
})
export class CreateTicketTypeComponent implements OnInit {

  ticketType: TicketType

  // @ts-ignore
  @ViewChild("closeButton") closeButton: ElementRef;
  @Output() onCreate: EventEmitter<any> = new EventEmitter();

  constructor(private ticketService: TicketService) { }

  ngOnInit() {
    this.ticketType = new TicketType()
  }

  onCreateSelected() {
    this.ticketService.createTicketType(this.ticketType).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onCreate.emit()
    })
  }
}
