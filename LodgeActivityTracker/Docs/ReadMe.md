# Lodge Activity Tracker

A web-based Lodge Activity Management application built using **ASP.NET Core MVC**.  
The system allows admins to manage lodge activities, track attendance via QR codes, approve activities, and provide an activity dashboard.

---

## Table of Contents
- [Features](#features)
- [System Requirements](#system-requirements)
- [Architecture](#architecture)
- [Entity Relationship Diagram (ERD)](#entity-relationship-diagram-erd)
- [Setup Instructions](#setup-instructions)
- [Screenshots](#screenshots)
- [Technology Stack](#technology-stack)
- [Contributors](#contributors)
- [License](#license)

---

## Features
- Add, edit, view, and delete lodge activities
- Store activity details including title, description, date & time, status, and QR code
- Generate QR codes for attendance tracking
- Approve or reject activities
- Dashboard to display pending approvals, approved activities, and statistics
- Identity-based authentication for admin login
- Role-based access control

---

## System Requirements
- .NET 7.0 or higher
- Visual Studio 2022 or VS Code
- SQL Server or SQLite (for development)
- Modern browser (Chrome, Edge, Firefox)

---

## Architecture
Lodge Activity Tracker follows the **MVC (Model-View-Controller)** design pattern:

- **Models**: Represent database entities such as Activity, ActivityStatus, ActivityApproval, and ViewModels.
- **Views**: Razor pages for displaying data and interacting with users (Admin, Account, Activities, Home).
- **Controllers**: Handle HTTP requests and business logic (AdminController, AccountController, ActivitiesController, HomeController).
- **Data Layer**: ApplicationDbContext and Migrations for database access and schema management.
- **Helpers**: QRCodeHelper for generating QR codes.
- **Seeders**: AdminSeeder for seeding default admin accounts.

![Architecture Diagram](./architecture (3).png)

---

## Entity Relationship Diagram (ERD)
The ERD diagram illustrates the database structure for Lodge Activity Tracker:

![ERD Diagram](./Requirements.png)

**Entities:**
- **User**: IdentityUser (from ASP.NET Identity)
- **Activity**
  - Id
  - Title
  - Description
  - DateTime
  - StatusId (FK → ActivityStatus)
  - ApprovalId (FK → ActivityApproval)
  - QRCode
- **ActivityStatus**
  - Id
  - Name (Pending, Approved, Rejected)
- **ActivityApproval**
  - Id
  - ApprovedBy (FK → Admin)
  - ApprovedDate

**Relationships:**
- ActivityStatus ↔ Activity (1:N)
- ActivityApproval ↔ Activity (1:1)
- User ↔ Activity (Many-to-Many for attendance)

---

## Setup Instructions
1. Clone the repository.
2. Update `appsettings.json` with your database connection string.
3. Open the project in Visual Studio or VS Code.
4. Run `Update-Database` in the Package Manager Console to apply migrations.
5. Seed the default admin using `AdminSeeder`.
6. Run the application using `dotnet run` or IIS Express.

---

## Screenshots
*You can add screenshots of your dashboards, activity forms, and QR code pages here.*

---

## Technology Stack
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / SQLite
- Razor Pages
- Bootstrap (optional for UI)
- QR Code generator

---

## Contributors
- [Your Name] – Developer
- [Other Contributors] – Roles

---

## License
MIT License
