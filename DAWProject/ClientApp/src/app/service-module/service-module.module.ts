import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import {FormsModule} from "@angular/forms";
import { ViewTicketsComponent } from './view-tickets/view-tickets.component';



@NgModule({
  declarations: [CreateTicketComponent, ViewTicketsComponent],
    imports: [
        CommonModule,
        FormsModule
    ],
  exports: [CreateTicketComponent, ViewTicketsComponent]
})
export class ServiceModuleModule { }
