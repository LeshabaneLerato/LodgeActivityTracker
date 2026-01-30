# Lodge Activity Tracker – System Requirements and Architecture

## 1. System Overview
Lodge Activity Tracker is a web-based application developed using **ASP.NET Core MVC**.  
The system is designed to manage lodge activities, track attendance via QR codes, approve activities, and provide an admin dashboard for centralized management.

---

## 2. Functional Requirements

1. The system shall allow admins to add, edit, view, and delete lodge activities.
2. The system shall store activity details including title, description, date & time, status, and QR code.
3. The system shall generate a QR code for each activity for attendance tracking.
4. The system shall allow admins to approve or reject activities.
5. The system shall track user attendance for each activity using QR codes.
6. The system shall display a dashboard with summary information such as total activities, pending approvals, and approved activities.
7. The system shall provide secure login for admins using ASP.NET Identity.
8. The system shall enforce role-based access control for admin and user operations.

---

## 3. Non-Functional Requirements

1. The system shall be easy to use and user-friendly.
2. The system shall validate all user input.
3. The system shall store data securely using a relational database.
4. The system shall provide acceptable response time for all operations.
5. The system shall be maintainable, scalable, and extensible.
6. The system shall follow MVC architectural best practices.

---

## 4. Entity Relationship Diagram (ERD)

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
