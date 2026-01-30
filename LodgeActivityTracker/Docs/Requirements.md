# Lodge Activity Tracker - Requirements

## 1. Introduction
The Lodge Activity Tracker (LAT) is a web-based system designed to manage lodge activities, staff, guests, and reporting efficiently. The system provides role-based access, activity scheduling, booking management, and analytics.

## 2. Functional Requirements

### 2.1 User Management
- Admin can create, update, and delete users (Staff, Guests).
- Role-based access control: Admin, Staff, Guest.
- Password management and authentication (login/logout).

### 2.2 Activity Management
- Admin/Staff can create, update, and delete activities.
- Activities have:
  - Name, description, date, start/end time
  - Location and capacity
  - Created by Admin/Staff
- Assign staff to specific activities.

### 2.3 Booking Management
- Guests can view available activities on Home page.
- Guests can book activities (future extension).
- System tracks attendee count to prevent overbooking.

### 2.4 Pages / Modules
1. **Home Page**
   - Displays upcoming activities.
   - Accessible to all users.
2. **Add Activity Page**
   - Form to create new activities (Admin/Staff only).
3. **Dashboard**
   - View, edit, delete activities.
   - View attendee stats.
4. **Admin Login**
   - Authentication for Admin access.

### 2.5 Notifications
- Email notifications for bookings, updates, or cancellations.

### 2.6 Reporting
- Admin can generate activity reports.
- Export as PDF or Excel.

### 2.7 Security
- HTTPS communication.
- Password hashing and secure storage.
- Role-based access control.

## 3. Non-Functional Requirements
- **Performance:** Support up to 500 concurrent users.
- **Usability:** Intuitive user interface.
- **Availability:** 99% uptime.
- **Scalability:** Modular system to add lodges or modules.
- **Maintainability:** Easy updates and bug fixes.
- **Compliance:** GDPR/POPIA regulations.

## 4. Activity Model

| Field        | Type       | Description                          |
|--------------|-----------|--------------------------------------|
| id           | Integer   | Unique identifier                     |
| title        | String    | Name of the activity                  |
| description  | Text      | Details of the activity               |
| date         | Date      | Date of the activity                  |
| start_time   | Time      | Start time                            |
| end_time     | Time      | End time                              |
| location     | String    | Activity location                      |
| capacity     | Integer   | Max number of participants            |
| created_by   | User (FK) | Admin/Staff who created the activity |
| created_at   | DateTime  | Timestamp of creation                 |
| updated_at   | DateTime  | Timestamp of last update              |

## 5. Use Case / Interaction Diagram

```plaintext
        +------------------+
        |      Admin       |
        +------------------+
        | Add/Edit/Delete  |
        | Activities       |
        | View Dashboard   |
        +------------------+
                |
                v
        +------------------+
        |    Activity      |
        +------------------+
        | title, desc, date|
        | start/end time   |
        | location, capacity|
        | created_by       |
        +------------------+
           ^          ^
           |          |
           |          |
+----------------+  +----------------+
|    Dashboard   |  |    Add Activity |
+----------------+  +----------------+
| View/Edit/Delete|  | Create activity|
| Activities     |  | form           |
+----------------+  +----------------+
           ^
           |
           v
        +------------------+
        |      Home        |
        +------------------+
        | Display upcoming |
        | activities       |
        +------------------+
           ^
           |
           v
        +------------------+
        |      Guest       |
        +------------------+
        | View Activities  |
        | Book Activities  |
        +------------------+
