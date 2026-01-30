# Lodge Activity Tracker – System Architecture

## 1. Architecture Overview
Lodge Activity Tracker follows the **Model-View-Controller (MVC)** architecture pattern.  
This architecture separates the application into three main layers: Model, View, and Controller, improving maintainability, scalability, and testability.

---

## 2. MVC Architecture

### 2.1 Model Layer
The Model layer represents the application’s data and business rules.  
It includes the following models:
- Activity
- ActivityStatus
- ActivityApproval
- UserActivity (tracking attendance)
- ErrorViewModel
- AdminDashboardViewModel

### 2.2 View Layer
The View layer is responsible for displaying data to the user.  
It uses **Razor views** with HTML, CSS, and optionally Bootstrap for styling.  
Views are organized into folders:
- Admin
- Account
- Activities
- Home
- Shared
- QRCode

### 2.3 Controller Layer
The Controller layer handles user requests, processes business logic, and communicates between the Model and View layers.  
Controllers include:
- AdminController
- AccountController
- ActivitiesController
- HomeController

---

## 3. Technology Stack
- **Frontend:** HTML, CSS, Bootstrap, Razor Views
- **Backend:** ASP.NET Core MVC (C#)
- **Database:** SQL Server (or SQLite for development)
- **ORM:** Entity Framework Core
- **QR Code Generation:** QRCodeHelper class
- **Authentication & Authorization:** ASP.NET Identity

---

## 4. Entity Relationship Diagram (ERD)

The ERD illustrates the structure of the database and the relationships between the core entities used in the Lodge Activity Tracker system.

```mermaid
erDiagram
    USER ||--o{ USER_ACTIVITY : attends
    ACTIVITY ||--|{ USER_ACTIVITY : includes
    ACTIVITY ||--|{ ACTIVITY_APPROVAL : approved_by
    ACTIVITY_STATUS ||--o{ ACTIVITY : has_status

    USER {
        int UserId
        string UserName
        string Email
    }

    ACTIVITY {
        int ActivityId
        string Title
        string Description
        date DateTime
        string QRCode
    }

    USER_ACTIVITY {
        int UserActivityId
        int UserId
        int ActivityId
        date AttendanceDate
    }

    ACTIVITY_STATUS {
        int StatusId
        string Name
    }

    ACTIVITY_APPROVAL {
        int ApprovalId
        int ApprovedBy (FK → Admin)
        date ApprovedDate
    }
