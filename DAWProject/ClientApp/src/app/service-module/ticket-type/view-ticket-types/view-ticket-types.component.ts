import {Component, OnInit} from '@angular/core';
import {TicketType} from "../../model/Ticket";
import {TicketService} from "../../ticket.service";

@Component({
  selector: 'app-view-ticket-types',
  templateUrl: './view-ticket-types.component.html',
  styleUrls: ['./view-ticket-types.component.css']
})
export class ViewTicketTypesComponent implements OnInit {
  ticketTypes: Array<TicketType>;
  selectedTicketType: TicketType;

  constructor(private ticketService: TicketService) { }

  ngOnInit() {
    this.loadTicketTypes()
  }

  onSelectTicketType(ticketType: TicketType) {
    this.selectedTicketType = ticketType
  }

  onEdited() {
    this.loadTicketTypes()
  }

  onDeleted() {
    this.loadTicketTypes()
  }

  private loadTicketTypes() {
    this.ticketService.getTicketTypes().subscribe(result => {
      this.ticketTypes = result
    })
  }

  onCreated() {
    this.loadTicketTypes()
  }
}
