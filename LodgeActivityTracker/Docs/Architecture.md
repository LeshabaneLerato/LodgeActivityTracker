# Lodge Activity Tracker - System Architecture

## 1. Overview
The Lodge Activity Tracker (LAT) is a **web-based application** designed to manage lodge activities, staff, and guests efficiently. It follows a **3-tier architecture**:

1. **Presentation Layer (Frontend)** – User interface for Admin, Staff, and Guests  
2. **Application Layer (Backend)** – Business logic for activities, approvals, bookings, and reporting  
3. **Data Layer (Database)** – Stores all persistent data (users, activities, bookings, logs)  

The system also interacts with external services like email notifications.

---

## 2. System Components

### 2.1 Presentation Layer
- **Pages / Modules**:
  - **Home Page:** Displays approved activities for Guests
  - **Add Activity Page:** Allows Admin/Staff to create or propose activities
  - **Dashboard:** Admin view to manage activities (Create/Edit/Approve/Reject/Delete)
  - **Admin Login:** Authentication for Admin access
- Built with **HTML, CSS, JS**, optionally frameworks like **React** or **Angular**

### 2.2 Application Layer
- Implements **business logic**:
  - Activity lifecycle: Create, Edit, Approve, Reject, Delete
  - Role-based access control (Admin, Staff, Guest)
  - Booking management
  - Reporting & analytics
- Built with **ASP.NET Core**, **Node.js**, or **Django**

### 2.3 Data Layer
- **Relational Database** (SQL Server / MySQL)
- Stores:
  - Users & roles
  - Activities (including status: Pending, Approved, Rejected)
  - Bookings
  - Logs and reports
- Ensures data integrity and supports queries for reporting

### 2.4 External Services
- **Email Notifications** for activity approval/rejection and booking updates
- Optional analytics or reporting tools

---

## 3. Architecture Diagram

```plaintext
                  +------------------+
                  |      Users       |
                  | Admin / Staff /  |
                  | Guests           |
                  +--------+---------+
                           |
                           v
                  +------------------+
                  |  Presentation    |
                  |    Layer         |
                  | Home, Dashboard, |
                  | Add Activity,    |
                  | Admin Login      |
                  +--------+---------+
                           |
                           v
                  +------------------+
                  |  Application     |
                  |    Layer         |
                  | Activity Lifecycle|
                  | (Create/Edit/    |
                  | Approve/Reject)  |
                  | Booking, Reporting|
                  +--------+---------+
                           |
                           v
                  +------------------+
                  |   Data Layer     |
                  | SQL Database     |
                  | Users, Activities|
                  | Bookings, Logs   |
                  +--------+---------+
                           |
                           v
                  +------------------+
                  | External Services|
                  | Email, Analytics |
                  +------------------+
