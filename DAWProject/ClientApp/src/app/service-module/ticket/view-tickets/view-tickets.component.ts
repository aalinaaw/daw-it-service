import { Component, OnInit } from '@angular/core';
import {Ticket} from "../../model/Ticket";
import {TicketService} from "../../ticket.service";
import {AuthService} from "../../../user-module/auth.service";

@Component({
  selector: 'app-view-tickets',
  templateUrl: './view-tickets.component.html',
  styleUrls: ['./view-tickets.component.css']
})
export class ViewTicketsComponent implements OnInit {
  tickets: Array<Ticket>;
  selectedTicket: Ticket;
  showForEmployee: boolean;

  constructor(private ticketService: TicketService, private authService: AuthService) { }

  ngOnInit() {
    const employeeValue = this.authService.currentEmployeeValue;
    if(employeeValue != null) {
      this.ticketService.getTicketsByEmployeeId(employeeValue.id).subscribe(result => {
        this.tickets = result;
        this.showForEmployee = true
      })
    } else {
      const userId = this.authService.currentUserValue.id;
      this.ticketService.getTicketsByUserId(userId).subscribe(result => {
        this.tickets = result;
        this.showForEmployee = false
      })
    }
  }

  getTicketEmployees(ticket: Ticket) {
    return ticket.employees.map(employee => {
      return employee.username
    }).join(", ")
  }

  onDelete() {
    const employeeValue = this.authService.currentEmployeeValue;
    if(employeeValue != null) {
      this.ticketService.getTicketsByEmployeeId(employeeValue.id).subscribe(result => {
        this.tickets = result;
      })
    } else {
      const userId = this.authService.currentUserValue.id;
      this.ticketService.getTicketsByUserId(userId).subscribe(result => {
        this.tickets = result;
      })
    }
  }

  onEdit() {
    const employeeValue = this.authService.currentEmployeeValue;
    if(employeeValue != null) {
      this.ticketService.getTicketsByEmployeeId(employeeValue.id).subscribe(result => {
        this.tickets = result;
      })
    } else {
      const userId = this.authService.currentUserValue.id;
      this.ticketService.getTicketsByUserId(userId).subscribe(result => {
        this.tickets = result;
      })
    }
  }

  onSelectEdit(ticket: Ticket) {
    this.selectedTicket = ticket
  }
}
