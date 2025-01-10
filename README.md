# Employee Management System (EMS)

### Project Overview
Employee Management System (EMS) is a distributed backend application based on a microservices architecture. It is designed to manage employee information, education records, and related operations. The project utilizes RabbitMQ as a message broker for communication between microservices and is accessible through a central Gateway service.

### Key Features
- **Microservices Architecture**: Modular design with separate services for Employees, Education, Employee Records, and more.
- **Gateway Service**: A centralized entry point for API requests, routing traffic to appropriate microservices.
- **RabbitMQ Integration**: Enables efficient and reliable communication between microservices.
- **Onion Architecture**: Ensures scalability, maintainability, and separation of concerns.
- **Domain Libraries**: Shared resources packaged as NuGet libraries for reusability across the microservices.

### Project Structure
The project is divided into the following components:

#### Domain
- **EMS.Dto**: Contains Data Transfer Objects for inter-service communication.
- **EMS.EventBus**: Manages events and messaging abstractions.
- **EMS.Shared**: Includes shared utilities, interfaces, and common functionality.

#### Microservices
- **EMS.Contracts**: Manages employee contracts, including employment agreements (e.g., "umowa o pracę," "umowa o dzieło," "umowa zlecenia").
- **EMS.Education**: Manages education-related data and processes.
- **EMS.EmployeeRecords**: Handles employee record management.
- **EMS.Employees**: Manages core employee data and operations.
- **EMS.Gateway**: Central API gateway service for routing and aggregating requests.

### Running the Application
1. Ensure Docker and Docker Compose are installed and running on your machine.
2. Clone the repository:
   ```bash
   git clone https://github.com/Original-organization-name/EMS-api_53004_52325.git
   cd EMS
3. Start the application using Docker Compose:
    ```bash
   docker-compose -f compose/compose.yaml up --build
4. Access the application:
   - Api Gateway: http://localhost:5000
   - RabbitMQ Management: http://localhost:15672
   
### Communication and Messaging

The application leverages RabbitMQ to handle asynchronous messaging between microservices. This allows for loose coupling and efficient processing of events.