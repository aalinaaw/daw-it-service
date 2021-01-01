# daw-it-service
School project for DAW course. It is an IT Service platform.

# Documentation

The present repository contains the implementation of an IT Service platform 
built using .NET Core and Angular.

 # Database Layer
 
 The database to be used is an instance of mssql-2019 with a default 
 connectivity configuration. Please check the appsettings files for the
 required password and user name.
 
 # Code base
 
 Starting from top to bottom, we have a Web API constructed from 5 
 controllers, each implemented to have a CRUD functionality for the 
 entities within our application.
 
 #### Ticket Controller
 The first and the most important is the Tickets API via which we expose 
 all CRUD functionalities for the Ticket Entity.
 
 #### Service Type Controller
 The next is the Service Type API via which we expose 
 all CRUD functionalities for the ServiceType Entity.  
 This serves as extra metadata for all tickets, such that users can select what type of issues they have.
  
 #### Authentication Controller
 This controller is mainly used when authenticating a user or an employee.
 It also serves as the entry point for the whole authentication mechanism because once a user is
 logged in, he receives a token with which all his actions are authorised.
  
 #### Users Controller
 This one is used to create users via the register form and CRUD on User Types.
 
 #### Employee Controller
 This controller is used to create employees within the platform.  
 The creation API is accessible via a POST request and was left like this
 for development purposes.
 
 # Use Cases
 An employee can use the ticket types page to create, modify or delete existing types.
 He can also modify the status of a ticket to show how it has progressed
  
 A user can create a ticket, view all the tickets he has created and their state.
 
 #### How employees are assigned when a ticket is created
 I've implemented a mechanism which assigns employees randomly to a ticket.   
 It consists in retrieving the total number of employees in the database, picking random number to select
 how many employees will be assigned to it and creating entries in the many-to-many table to associate them to
 the ticket at hand.
 
 #### Login
 There are two login pages, one for users and the other for employees. The logic behind this was to separate
 the entities and give them different scopes. Also perhaps add a layer of security/privileges to what a user 
 can do based on his type.
 
 