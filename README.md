# Employee Manager System (EMS) API

### Project Overview
Employee Manager System (EMS) API is a backend application built with ASP.NET Core and Entity Framework Core to manage employee information. The API provides endpoints to perform CRUD operations on employee data and serves as the backend for the EMS Angular frontend.

This README file provides an overview of the project, setup instructions, and steps to run the application using Docker Compose.

### Run Docker Compose
1.Ensure Docker and Docker Compose are installed and running on your machine.
2. Clone the repository:
```
> git clone https://github.com/Original-organization-name/EMS-api_53004_52325.git
> cd EMS
```
3. Running the Application
```
docker-compose -f compose\compose.yaml up --build
```
4. The API will be available at http://localhost:5000, pgAdmin at http://localhost:8888


## Structure
The EMS API is a scalable and maintainable application developed using Onion Architecture, C# and Entity Framework Core. The project is structured into several layers, each with its own responsibility, to ensure separation of concerns and ease of testing.

- **EMS.Data**: This layer contains the data access logic, entity models, and database context definitions.
- **EMS.DTO**: This layer includes Data Transfer Objects for transferring data between processes.
- **EMS.Services**: The service layer where business logic is implemented.
- **EMS.Shared**: Contains shared resources like common utilities or interfaces.
- **EMS.Presentation**: Holds the presentation logic, which could be views or controllers in an MVC application.
- **EMS.PersistenceLayer**: Includes classes that interact with the database using EF Core, like repositories.
