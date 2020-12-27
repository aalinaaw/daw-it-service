import {User} from "../../user-module/model/User";

export class TicketType {
  id: string;
  serviceName: string;
}

export class Ticket {
  id: string;
  description: string;
  ticketType: TicketType;
  employees: Array<User>;
  userId: string;
  username: string;
  status: string;
}
