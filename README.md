# RocketCV - Job Positions Management

## Introduction

RocketCV is a CV management system for ABC Company. This README provides an overview of the new functionality added to manage job positions within the system.

## ABC Company

ABC Company is a reputable and innovative organization that has been a prominent player in the business world for over two decades. Founded in 2024, ABC Company has consistently demonstrated its commitment to excellence, growth, and customer satisfaction on the recluitment industry.

## User Story

### Managing Job Positions in RocketCV

**As** a hiring manager or CV creator at ABC Company,
**I want** to be able to control and manage job positions within the existing RocketCV system,
**So that** I can effectively organize and maintain the CVs with accurate job position information.

### Acceptance Criteria

1. **Create Job Positions**
   - **Given** I am logged into the RocketCV system,
   - **When** I navigate to the "Job Positions" section,
   - **Then** I should be able to create a new job position by providing a title, description, and any other relevant details.

2. **Read Job Positions**
   - **Given** I am logged into the RocketCV system,
   - **When** I navigate to the "Job Positions" section,
   - **Then** I should be able to view a list of all existing job positions with their respective details.

3. **Update Job Positions**
   - **Given** I am logged into the RocketCV system,
   - **When** I navigate to the "Job Positions" section,
   - **And** I select a specific job position,
   - **Then** I should be able to edit and update its title, description, or any other details as needed.

4. **Delete Job Positions**
   - **Given** I am logged into the RocketCV system,
   - **When** I navigate to the "Job Positions" section,
   - **And** I select a specific job position,
   - **Then** I should be able to delete that job position, which will remove it from the system.

### Technical Details

- Job position data is stored in a MongoDB NoSQL database.
- The functionality is implemented using .NET 8.0 and C#.
- Services are containerized using Docker to ensure easy deployment and scalability.
- Unit tests are written to verify the CRUD operations for job positions.
- The user interface provides a user-friendly way to perform these CRUD operations.

## Getting Started

Follow the instructions below to set up and run the RocketCV system with the new job positions management functionality.

### Prerequisites

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- MongoDB (configured and accessible)

### Installation

1. Clone the RocketCV repository to your local machine.

   ```shell
   git clone https://github.com/andresRah/RocketCV.git
   cd rocketcv
   docker-compose build
   docker-compose up -d
   ```

### Postman Documentation

Check the root folder - RocketCV.postman_collection

https://documenter.getpostman.com/view/25622630/2s9YsJDDVz

### Execution Postman
![image](https://github.com/andresRah/RocketCV/assets/10521199/14f02826-8679-47d2-852d-6fe843c89c53)

Setup the port number in the variables section, and the run the endpoints in order from 1 to 9
![image](https://github.com/andresRah/RocketCV/assets/10521199/112c9c55-8f02-4add-a757-8fea8c217092)

### Testing
   ```shell
   dotnet test
   ```

# RocketCV Architecture Overview

The RocketCV project is designed with a multi-layered architecture to ensure modularity, scalability, and maintainability. Each layer in the architecture serves a specific purpose and helps organize the codebase effectively. Below is an overview of the key layers and their responsibilities:

## Layers

### 1. RocketCV.Data (Data Access Layer)

- **Responsibility:** This layer is responsible for data access and communication with the MongoDB database. It encapsulates the database-related operations, such as CRUD (Create, Read, Update, Delete) operations on job positions and other data entities.

### 2. RocketCV.Models (Business Layer)

- **Responsibility:** The business layer contains all business logic, domain models, and entities. It defines the structure of data and represents the core business concepts of the RocketCV system, including job positions, CVs, and other relevant entities.

### 3. RocketCV.Services (Service Layer)

- **Responsibility:** The service layer is responsible for developing the business logic, complex calculations, and overall application logic. It acts as the bridge between the business layer (RocketCV.Models) and the data access layer (RocketCV.Data). Services handle the interaction between different parts of the system and implement use cases.

### 4. RocketCV.Tests (Testing Project)

- **Responsibility:** Following the Test-Driven Development (TDD) concept, this project is dedicated to writing unit tests for various components of the RocketCV system. Tests ensure that the system functions correctly, and any changes or updates do not introduce regressions.

### 5. RocketCV.Utils (Utilities)

- **Responsibility:** This layer contains utility functions, helper classes, and common functionality that are required across different layers of the application. It promotes code reusability and maintains clean, modular code.

### 6. RocketCV (Controllers and Services)

- **Responsibility:** The top layer of the architecture includes controllers responsible for handling HTTP requests and serving as entry points to the application. Controllers interact with services from the service layer to process incoming requests, apply business logic, and return responses to clients.

## Benefits of the Architecture

- **Modularity:** The architecture promotes modularity, making it easier to develop and maintain different components of the RocketCV system independently.

- **Separation of Concerns:** Each layer has a distinct responsibility, ensuring a clear separation of concerns. This separation enhances code readability and maintainability.

- **Scalability:** The modular structure allows for scalability by adding or modifying components as the application grows or evolves.

- **Testability:** The inclusion of a dedicated testing project facilitates the testing of various components, ensuring robust and reliable software.

- **Code Reusability:** Utilities and common functionality in the Utils layer promote code reusability and consistency.

- **Maintainability:** The organization of the codebase based on layers makes it easier to understand and maintain the application over time.

This multi-layered architecture ensures that the RocketCV project is well-structured and capable of meeting current and future business needs. Developers can work on specific components with clarity and confidence, ultimately delivering a robust and efficient CV management system.

## Additional Considerations

Follow the instructions below to set up and run the RocketCV system with the new job positions management functionality.

- Ensure that proper authentication and authorization mechanisms are in place to control access to job positions based on user roles and permissions.
- Implement error handling and validation to provide a smooth user experience.
- Consider implementing versioning for job positions if necessary.
- Monitor and log system activities related to job positions for auditing purposes.

## License

This project is licensed under the MIT License.
