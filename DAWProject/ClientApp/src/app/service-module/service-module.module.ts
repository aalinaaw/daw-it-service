import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import {FormsModule} from "@angular/forms";
import { ViewTicketsComponent } from './view-tickets/view-tickets.component';
import { ViewTicketTypesComponent } from './ticket-type/view-ticket-types/view-ticket-types.component';
import { CreateTicketTypeComponent } from './ticket-type/create-ticket-type/create-ticket-type.component';
import { EditTicketTypeComponent } from './ticket-type/edit-ticket-type/edit-ticket-type.component';
import { EditTicketComponent } from './edit-ticket/edit-ticket.component';



@NgModule({
  declarations: [CreateTicketComponent, ViewTicketsComponent, ViewTicketTypesComponent, CreateTicketTypeComponent, EditTicketTypeComponent, EditTicketComponent],
    imports: [
        CommonModule,
        FormsModule
    ],
  exports: [CreateTicketComponent, ViewTicketsComponent, ViewTicketTypesComponent, CreateTicketTypeComponent, EditTicketTypeComponent]
})
export class ServiceModuleModule { }
