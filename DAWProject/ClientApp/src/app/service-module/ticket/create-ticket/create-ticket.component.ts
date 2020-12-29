import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {Ticket, TicketType} from "../../model/Ticket";
import {TicketService} from "../../ticket.service";
import {AuthService} from "../../../user-module/auth.service";



@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.css']
})
export class CreateTicketComponent implements OnInit {
  ticket = new Ticket();
  ticketTypes = Array<TicketType>();

  constructor(private router: Router, private ticketService: TicketService, private authService: AuthService) {
  }

  ngOnInit() {
    this.ticketService.getTicketTypes().subscribe(result => {
      this.ticketTypes = result;
      this.ticket.ticketType = this.ticketTypes[0];
    });
  }

  onSelectTicketType(ticketType: TicketType) {
    this.ticket.ticketType = ticketType;
  }

  onCreateTicket() {
    this.ticket.userId = this.authService.currentUserValue.id
    this.ticketService.createTicket(this.ticket).subscribe(result => {
      this.router.navigate(["/"]);
    });
  }
}
