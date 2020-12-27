import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Ticket, TicketType} from "./model/Ticket";

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private readonly baseUrl: string) {}

  public getTicketTypes() {
    return this.http.get<Array<TicketType>>( `${this.baseUrl}api/servicetype`);
  }

  createTicket(ticket: Ticket) {
    return this.http.post( `${this.baseUrl}api/ticket`, ticket);
  }

  getTicketsByEmployeeId(employeeId: string) {
    return this.http.get<Array<Ticket>>( `${this.baseUrl}api/ticket/employee/${employeeId}`);
  }

  getTicketsByUserId(userId: string) {
    return this.http.get<Array<Ticket>>( `${this.baseUrl}api/ticket/user/${userId}`);
  }

  updateTicketType(ticketType: TicketType) {
    return this.http.put( `${this.baseUrl}api/servicetype`, ticketType);
  }

  deleteTicketType(ticketTypeId: string) {
    return this.http.delete( `${this.baseUrl}api/servicetype/${ticketTypeId}`);
  }

  createTicketType(ticketType: TicketType) {
    return this.http.post( `${this.baseUrl}api/servicetype/`, ticketType);
  }

  updateTicket(ticket: Ticket) {
    return this.http.put( `${this.baseUrl}api/ticket`, ticket);
  }

  deleteTicket(ticketId: string) {
    return this.http.delete( `${this.baseUrl}api/ticket/${ticketId}`);
  }
}
