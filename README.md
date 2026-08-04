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
