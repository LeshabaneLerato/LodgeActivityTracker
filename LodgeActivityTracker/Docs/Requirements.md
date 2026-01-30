# Lodge Activity Tracker - Requirements

## 1. Introduction
The Lodge Activity Tracker is a web-based application designed to manage lodge-related activities, track user participation, and provide administrative oversight. It is built using **ASP.NET Core MVC** with **Entity Framework Core** for database operations.

## 2. Functional Requirements
1. **User Management**
   - Users can register and log in.
   - Admins can manage users, approve activities, and monitor activity status.

2. **Activity Management**
   - Admins can create, edit, delete, and approve activities.
   - Activities have the following properties:
     - Title
     - Description
     - Date & Time
     - Status (Pending, Approved, Rejected)
     - QR Code for attendance tracking
   - Users can view activities and register attendance via QR codes.

3. **Dashboard**
   - Admin dashboard shows:
     - List of activities
     - Pending approvals
     - Activity statistics

4. **Notifications**
   - Optional: Notify users when activities are approved or updated.

5. **Security**
   - Identity-based authentication for admin login.
   - Role-based access control for activities and admin operations.

## 3. Non-Functional Requirements
1. **Performance**
   - Load dashboard within 3 seconds.
   - Efficient queries for activities list.

2. **Usability**
   - User-friendly and responsive UI.
   - QR code generation for easy activity check-in.

3. **Scalability**
   - Database design supports multiple lodges and multiple activities.

4. **Maintainability**
   - Clean MVC architecture for easier maintenance.
   - Seeders and helpers to reduce repetitive code.

## 4. System Requirements
- .NET 7.0 or later
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server or SQLite (for development)
- Browser: Chrome, Firefox, Edge

## 5. ERD Diagram
![ERD Diagram](requirements.png)

**Entities:**
- **User**: IdentityUser (from ASP.NET Identity)
- **Activity**
  - Id
  - Title
  - Description
  - DateTime
  - Status
  - QRCode
- **ActivityStatus**
- **ActivityApproval**

Relationships:
- User ↔ Activities (Many-to-Many if tracking attendance)
- Admin ↔ Activities (One-to-Many)
