# Contacts Web Application

This is a small web application to add, update and delete contact information.  The webpage will display the contact information and allow editing.

## Web API
The web API is .Net Core 7 and was written in C# using Visual Studio 2022.  The APi is described in the swagger page which will start when the application is run.  The ORM used is Entity Framework and the localdb provided with Visual Studio was used.  A DTO has been defined and is used in this project, however it isn't utilised in the front end as it's not compatiable.  I could of used it in a Blazor front end, for example, but chose Angular in the end.


## Front End UI
The front end UI is an Angular application which at this stage it is very basic.  VS Code was used to develop and run this front end.  A third party grid would probably bee the first improvement if this application was to be taken forward.  This app is very much still work in progress, but does perform the required functionality.  It does currently has a limitation that it needs an existing contact in the database to enable addition of new contacts.  The initial contact required can be added using the Swagger page in the web API.  An alternative would be to seed some data in the WEB API but this has not yet been implemented.

