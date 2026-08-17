# 📚 Refresher Training


---

# 📅 Day 1

## 🏥 Hospital Database

### Objective

Designed the initial relational database schema for a Hospital Management System using Microsoft SQL Server Management Studio (SSMS).

### Tasks Completed

* Designed the database schema.
* Created the **Doctor**, **Patient**, and **Appointment** tables.
* Defined **Primary Key** and **Foreign Key** relationships.
* Implemented **ON DELETE CASCADE** for referential integrity.
* Applied **NOT NULL**, **UNIQUE**, **CHECK**, and **DEFAULT** constraints.
* Generated the **Entity Relationship (ER) Diagram**.
* Documented relationships between entities.

### Database Entities

* **Doctor**
* **Patient**
* **Appointment**

### Concepts Covered

* Database Design
* Relational Model
* Primary & Foreign Keys
* Constraints
* Cascade Delete
* ER Diagram
* SQL Server (SSMS)

---

# 📅 Day 2

## 🏥 Project: Hospital Database

### Objective

Extended the Hospital Management System database and explored core database concepts, including normalization, indexing, query optimization, and execution plan analysis using Microsoft SQL Server Management Studio (SSMS).

### Tasks Completed

* Extended the existing database schema by creating the **Room** table.
* Implemented the **Doctor_Room** relationship table to assign doctors to consultation rooms.
* Practiced creating **Single-Column**, **Composite**, and **Covering Indexes**.
* Analyzed query performance using **SQL Server Execution Plans**.
* Compared query execution before and after applying indexes.
* Explored **First Normal Form (1NF)**, **Second Normal Form (2NF)**, and **Third Normal Form (3NF)** with practical database design examples.
* Designed and refined **Entity Relationship (ER) Diagrams** for the database schema.
* Practiced writing SQL queries related to schema extension, indexing, normalization, and query optimization.

### Concepts Covered

* Database Normalization (1NF, 2NF, 3NF)
* Indexing

  * Single-Column Index
  * Composite Index
  * Covering Index
* Query Optimization
* SQL Server Execution Plans
* ER Diagram Design
* Database Relationships
* Schema Extension
* SQL Server Management Studio (SSMS)

---
# 📅 Day 3

## 🏥 Project: Hospital Database

### Objective
Enhanced the Hospital Management System by implementing database automation using triggers and stored procedures, along with auditing database operations for improved data tracking and management.

### Tasks Completed
- Created a centralized **AuditLog** table to maintain records of database operations.
- Implemented **AFTER INSERT**, **AFTER UPDATE**, and **AFTER DELETE** triggers for the **Doctor** table.
- Implemented **AFTER INSERT**, **AFTER UPDATE**, and **AFTER DELETE** triggers for the **Patient** table.
- Implemented **AFTER INSERT**, **AFTER UPDATE**, and **AFTER DELETE** triggers for the **Appointment** table.
- Configured triggers to automatically record:
  - Table Name
  - Operation Type
  - Record ID
  - Previous Values
  - Updated Values
- Displayed operation-specific confirmation messages using `PRINT` statements.
- Created stored procedures for performing **Insert**, **Update**, and **Delete** operations on the **Doctor** table.
- Executed and verified stored procedures and triggers using sample data.
- Populated the database with sample doctor and patient records for testing.

### Concepts Covered
- Database Triggers
- Stored Procedures
- Audit Logging
- Data Auditing
- INSERT, UPDATE & DELETE Operations
- SQL Server Stored Procedure Execution
- Trigger-Based Automation
- Database Testing
- SQL Server Management Studio (SSMS)

---
# 📅 Day 4

## 🏥 Project: Hospital Database

### Objective
Developed a layered ADO.NET console application to perform CRUD operations on the Hospital Database while demonstrating both connected and disconnected database architectures.

### Tasks Completed
- Created a console-based Hospital Management application using .NET.
- Designed a layered project structure with:
  - Entity Layer
  - Service Layer
  - Menu Layer
- Implemented a reusable database connection class for SQL Server connectivity.
- Developed CRUD operations for the **Doctor** module using stored procedures.
- Developed CRUD operations for the **Patient**, **Appointment**, and **Room** modules using parameterized SQL queries.
- Built a nested console menu for managing different modules independently.
- Added exception handling using `try-catch-finally` blocks across all database operations.
- Implemented row validation using `ExecuteNonQuery()` to verify successful INSERT, UPDATE, and DELETE operations.
- Implemented **Connected Architecture** using `SqlConnection`, `SqlCommand`, and `SqlDataReader`.
- Implemented **Disconnected Architecture** in the Patient module using `SqlDataAdapter` and `DataSet`.
- Verified complete CRUD functionality for all database tables through the console application.

### Concepts Covered
- ADO.NET
- Connected Architecture
- Disconnected Architecture
- SqlConnection
- SqlCommand
- SqlDataReader
- SqlDataAdapter
- DataSet
- Parameterized Queries
- Stored Procedures
- CRUD Operations
---
## Day 5: Introduction to ASP.NET Core Web API

### Topics Covered
- Introduction to ASP.NET Core and Web APIs
- Understanding the ASP.NET Core project structure
- Installing and verifying .NET SDK versions
- Scaffolding a new ASP.NET Core Web API project using the .NET CLI
- Difference between .NET 8 (LTS) and .NET 10 Web API templates
- Understanding OpenAPI vs Swagger

### Learning Outcomes
- Understood the purpose of ASP.NET Core Web APIs and their use in building RESTful services.
- Learned how to scaffold a new Web API project using the .NET CLI.
- Explored the default project structure and the purpose of the generated files.
- Compared the .NET 8 (Swagger-based) and .NET 10 (OpenAPI-based) Web API templates.
- Configured the development environment for ASP.NET Core development.
- Successfully created and executed the first ASP.NET Core Web API project.
- Learned how Swagger simplifies API documentation and testing.

### Status
- ✔️ Development environment configured.
- ✔️ First ASP.NET Core Web API project scaffolded.
- ✔️ Ready to begin building controllers and RESTful APIs in the next session.


---
## Day 6: ASP.NET Core MVC & Web API Integration

### 📅 Date: 07 Aug 2026

### 📚 Topics Covered
- ASP.NET Core MVC Architecture
- MVC Folder Structure
- Controllers, Views & Routing
- Web API Creation
- API Routing using Attributes
- JavaScript Fetch API
- JSON Response Handling
- Session Storage
- Navigation between MVC Views

### 🛠️ Tasks Completed
- Created a new ASP.NET Core MVC application.
- Explored the default MVC project structure.
- Implemented an API Controller (`GreetingsController`) to return a JSON response.
- Created an MVC `HomeController` to serve application views.
- Built a Home page containing a **Get Greeting** button.
- Integrated JavaScript `fetch()` to consume the Web API asynchronously.
- Displayed the greeting only after receiving a successful API response.
- Implemented page redirection from the Home page to a separate Greeting page.
- Used `sessionStorage` to transfer API data between pages.
- Customized the default layout by removing the unused Privacy navigation link.
- Understood the complete request lifecycle:
  - Browser → MVC Controller → View
  - View → Web API → JSON Response
  - JavaScript → Redirect → Greeting View

### 📂 Project
**GreetingsApp**
- ASP.NET Core MVC
- ASP.NET Core Web API
- Razor Views
- JavaScript Fetch API

### 🎯 Learning Outcome
- Learned the responsibilities of MVC Controllers and API Controllers.
- Understood ASP.NET Core routing and endpoint mapping.
- Learned how MVC Views interact with Web APIs using JavaScript.
- Gained hands-on experience with asynchronous API calls and JSON handling.
- Understood how data can be passed between pages using browser session storage.
---
## Day 7 – ASP.NET Core Minimal API & Contacts CRUD

### Topics Covered
- ASP.NET Core Minimal APIs
- Minimal API endpoint mapping
- HTTP methods: GET, POST, PUT, DELETE
- Entity Framework Core
- DbContext and DbSet
- SQL Server integration using SSMS
- Connection strings
- CRUD operations
- API testing using Postman

### Practical Work
- Created a **Contacts CRUD application** using ASP.NET Core Minimal API.
- Created a `ContactsDB` database in SQL Server.
- Created the `Contacts` table with Id, Name, Email and Phone fields.
- Created the `Contact` model class.
- Created `ContactDbContext` for Entity Framework Core database interaction.
- Configured SQL Server connection using `appsettings.json`.
- Implemented all CRUD endpoints directly in `Program.cs` without using Controllers.
- Tested all API endpoints using Postman.

### Endpoints Implemented

| Method | Endpoint | Operation |
|--------|----------|-----------|
| GET | `/api/contacts` | Get all contacts |
| GET | `/api/contacts/{id}` | Get contact by ID |
| POST | `/api/contacts` | Create a contact |
| PUT | `/api/contacts/{id}` | Update a contact |
| DELETE | `/api/contacts/{id}` | Delete a contact |

### Key Learning
Learned how Minimal APIs simplify ASP.NET Core API development by defining HTTP endpoints directly in `Program.cs`, eliminating the need for Controllers while still supporting complete CRUD operations with Entity Framework Core and SQL Server.
---
# Day 8 – H2 Database, H2Sharp, ADO.NET & Minimal API Contacts App

## Date
11 August 2026

## Topics Covered

- H2 Database
- H2Sharp for .NET
- ADO.NET with H2
- H2Sharp and IKVM dependencies
- Minimal APIs
- Layered Architecture
- Repository Layer
- Service Layer
- SQL Server with ADO.NET
- Dependency Injection
- CRUD Operations
- Postman API Testing

---

## 1. H2 Database

Learned about **H2 Database**, a lightweight relational database commonly used for development, testing, and Java applications.


## 2. Using H2 with C#

Since H2 is primarily a Java database, using it from .NET requires a compatible provider.

Learned about **H2Sharp**, a .NET provider for accessing H2 from C#.

The H2Sharp provider uses **IKVM** to provide Java compatibility inside the .NET environment.

### Dependency Flow

```text
C# Application
      ↓
H2Sharp
      ↓
IKVM
      ↓
H2 Database
---
## Day 9 – EF Core ORM & Contacts CRUD API

### Topics Covered

* Entity Framework Core (EF Core)
* ORM concepts
* DbContext and DbSet
* EF Core with existing SQL Server database
* Controller-based ASP.NET Core Web API
* Repository and Service layers
* Dependency Injection
* CRUD operations using EF Core
* Postman API testing

### Work Done

* Created a Contacts CRUD application using **EF Core ORM**.
* Connected the application to the existing `ContactsDB` database on `localhost\SQLEXPRESS`.
* Created `Contact` model and `AppDbContext`.
* Implemented Repository and Service layers.
* Replaced manual ADO.NET database operations with EF Core operations using `DbContext` and `DbSet`.
* Added `ContactController` with GET, POST, PUT and DELETE endpoints.
* Tested all CRUD operations successfully using Postman.
* Learned how EF Core maps C# entities and properties to database tables and columns.
* Compared EF Core ORM with the manual ADO.NET approach used previously.

### Architecture

```text
Postman
   ↓
Controller
   ↓
Service
   ↓
Repository
   ↓
EF Core / DbContext
   ↓
Existing ContactsDB
```

### Key Learning

EF Core acts as an ORM that allows working with database records as C# objects, reducing the need to manually write `SqlConnection`, `SqlCommand`, `SqlDataReader`, and SQL queries for common CRUD operations.

---
## Day 10 – Employee Payroll System

### Objective
- Build a basic Employee Payroll System using ASP.NET Core Web API.
- Implement a proper layered architecture with separate projects.
- Use Entity Framework Core with SQL Server and migrations for database creation.
- Implement and test complete Employee CRUD operations.

### Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SSMS
- EF Core Migrations
- Postman
- Dependency Injection
- Layered Architecture

### Project Architecture
```text
EmployeePayroll
│
├── EmployeePayroll       → Web API / Presentation Layer
│   └── Controllers
│
├── Business              → Business Layer
│   ├── Interface
│   └── Service
│
├── Models                → Model Layer
│   ├── DTO
│   ├── Entity
│   └── Exceptions
│
└── Repository            → Data Access Layer
    ├── Context
    ├── Interface
    ├── Service
    └── Migrations

---
## Day 11 – Finished Employee Payroll 

### Objective

* Get started with ASP.NET Core Web APIs.
* Add Swagger for API documentation and testing.
* Revise EF Core and migrations.

### Work Done

* Explored the basic structure and flow of ASP.NET Core Web APIs.
* Added and configured `Swashbuckle.AspNetCore`.
* Integrated Swagger UI and tested existing Employee CRUD endpoints.
* Revised Entity Framework Core and `DbContext`.
* Revised EF Core migrations and the `dotnet ef` workflow.
* Reviewed the flow: Controller → Business → Repository → EF Core → SQL Server.
## Day 12 – Fundoo App: User Authentication & Backend Setup

### Fundoo App

Started development of the **Fundoo App**, a backend-first ASP.NET Core Web API project designed to be extended with multiple APIs and functionalities in future days.

#### Project Architecture

* Created a solution using a **4-layer architecture**:

  * **Fundoo** – ASP.NET Core Web API / Presentation Layer
  * **Business** – Business Logic Layer
  * **Repository** – Data Access Layer
  * **Models** – Entity, DTO and Exception Layer
* Added project references to establish the flow:
  **Controller → Business → Repository → Database**
* Created the required folder structure:

  * Business: `Interface`, `Service`
  * Models: `DTO`, `Entity`, `Exceptions`
  * Repository: `Context`, `Interface`, `Service`, `Migrations`

#### Database Integration

* Integrated **Entity Framework Core** with SQL Server.
* Created `ApplicationDbContext` for database operations.
* Created the `User` entity with:

  * `Id`
  * `FirstName`
  * `LastName`
  * `Email`
  * `PasswordHash`
* Configured the `FundooDb` database using a connection string.
* Created and applied the **InitialCreate EF Core migration**.
* Successfully created the `Users` table in the Fundoo database.

#### User Registration

* Created `RegisterRequestDTO` for registration requests.
* Implemented the Repository layer using:

  * `IUserRepository`
  * `UserRepository`
* Implemented the Business layer using:

  * `IUserService`
  * `UserService`
* Implemented `POST /api/User/register`.
* Added duplicate-email validation.
* Implemented secure password hashing using `PasswordHasher<User>`.
* Verified that passwords are stored as hashes instead of plain text.

#### User Login & JWT Authentication

* Created `LoginRequestDTO` and `AuthResponseDTO`.
* Implemented `POST /api/User/login`.
* Added password verification against the stored password hash.
* Implemented JWT token generation with user claims.
* Configured JWT Bearer Authentication in ASP.NET Core.
* Added JWT settings for issuer, audience, signing key and token expiry.
* Implemented a protected `GET /api/User/profile` endpoint using `[Authorize]`.
* Extracted authenticated user information from JWT claims.

#### Swagger Authentication

* Configured Swagger to support **Bearer JWT Authentication**.
* Added the Swagger **Authorize** functionality.
* Tested protected API access with and without a valid JWT token.
* Verified successful authentication and `401 Unauthorized` responses for unauthenticated requests.

### APIs Implemented

| Method | Endpoint             | Purpose                            |
| ------ | -------------------- | ---------------------------------- |
| POST   | `/api/User/register` | Register a new user                |
| POST   | `/api/User/login`    | Authenticate user and generate JWT |
| GET    | `/api/User/profile`  | Access authenticated user profile  |

### Concepts Covered

* ASP.NET Core Web API
* Layered Architecture
* Entity Framework Core
* SQL Server Database Integration
* EF Core Migrations
* DTOs
* Repository Pattern
* Dependency Injection
* Password Hashing
* JWT Authentication
* Authorization with `[Authorize]`
* JWT Claims
* Swagger API Testing

### Key Learnings

* Basics of ASP.NET Core Web APIs.
* Swagger/OpenAPI for API testing.
* EF Core and migration-based database management.
---
