
# Clinic Management System (CMS)

A comprehensive desktop application for managing clinic operations including patient records, doctor schedules, appointments, visits, prescriptions, invoices, and insurance processing. Built with a clean 3-tier architecture using C# WinForms and SQL Server.

---
<img width="948" height="521" alt="لقطة شاشة 2026-07-27 152355" src="https://github.com/user-attachments/assets/ae3eeb73-08bf-41a0-ad48-e94d364d5bf0" />
<img width="951" height="520" alt="لقطة شاشة 2026-07-27 152515" src="https://github.com/user-attachments/assets/d197e7e4-0d17-4653-9c3c-788a8f187bfa" />
<img width="950" height="526" alt="لقطة شاشة 2026-07-27 152504" src="https://github.com/user-attachments/assets/f6544bbf-0d0a-4cb0-a285-24fd7c4f2e9c" />
<img width="947" height="526" alt="لقطة شاشة 2026-07-27 152432" src="https://github.com/user-attachments/assets/2bdf618f-f3dd-49d4-a825-fa469623f744" />
<img width="949" height="522" alt="لقطة شاشة 2026-07-27 152410" src="https://github.com/user-attachments/assets/df3bc52c-2b3e-4756-a908-bb0e67fdcb49" />

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Database Design](#database-design)
- [Getting Started](#getting-started)
- [User Roles & Permissions](#user-roles--permissions)
- [Screenshots](#screenshots)
- [Future Improvements](#future-improvements)

---

## Overview

The Clinic Management System (CMS) is a Windows Forms desktop application designed to streamline the day-to-day operations of a medical clinic. It provides a centralized platform for managing patients, doctors, appointments, medical visits, prescriptions, and billing with integrated insurance support.

The system implements a strict **3-tier architecture** separating Data Access, Business Logic, and Presentation layers to ensure maintainability, scalability, and clean code organization.

---

## Features

### Patient Management
- Register and manage patient profiles with personal and medical information
- Track blood type, emergency contacts, and insurance details
- Search and filter patients by name, ID, blood type, or insurance company

### Doctor Management
- Manage doctor profiles, specialties, and license numbers
- Configure weekly working schedules (Monday–Sunday)
- Activate/deactivate doctors for appointment availability

### Appointment Scheduling
- Book appointments with real-time conflict detection
- Visual time-slot selection (9:00 AM – 5:00 PM, 20-minute intervals)
- Filter doctors by specialty or name
- Support for Pending, Completed, Cancelled, and No-Show statuses

### Medical Visits
- Record visit details: symptoms, diagnosis, and vital signs (BP, pulse, temperature)
- Add recommended medical services during the visit
- Generate and manage prescriptions with dosage and duration

### Prescriptions
- Create prescriptions linked to visits
- Add multiple medications with dosage and duration
- View prescription history per patient

### Invoicing & Insurance
- Auto-generate invoices from appointments with selected medical services
- Insurance coverage calculation with percentage-based discounts
- Payment status tracking: Paid, Unpaid, Partially_Paid
- Manage insurance companies and coverage policies

### User Management & Security
- Role-based access control (RBAC) with three roles: **Administrator**, **Receptionist**, and **Doctor**
- User activation/deactivation
- Password hashing for secure credential storage
- "Remember Me" functionality via Windows Registry

### Specialty/Department Management
- Create and manage medical specialties/departments
- Link doctors and services to specific specialties

---

## Architecture

The application follows a classic **3-Tier (N-Tier) Architecture**:

```
┌─────────────────────────────────────┐
│         Presentation Layer          │
│    (WinForms / CMS_UI namespace)    │
│  Forms, UserControls, Validators   │
└─────────────┬───────────────────────┘
              │
┌─────────────▼───────────────────────┐
│         Business Logic Layer        │
│   (CMSLogic namespace)              │
│  Domain Models, Enums, Rules       │
└─────────────┬───────────────────────┘
              │
┌─────────────▼───────────────────────┐
│          Data Access Layer          │
│    (CMSData namespace)              │
│  ADO.NET, Stored Procedures, SQL   │
└─────────────────────────────────────┘
```

### Design Patterns Used
- **Active Record Pattern**: Each business object (`clsPatient`, `clsDoctor`, etc.) encapsulates its own data access via `Find()` and `Save()` methods.
- **State Pattern**: `enMode` enum (`AddNew` / `Update`) controls object persistence behavior.
- **Repository Pattern**: Data classes (`clsPatientsData`, `clsDoctorsData`) abstract all database operations.

---

## Tech Stack

| Layer | Technology |
|-------|------------|
| **Frontend** | C# Windows Forms (.NET Framework) |
| **Backend** | C# Class Libraries |
| **Database** | Microsoft SQL Server |
| **Data Access** | ADO.NET (SqlConnection, SqlCommand, SqlDataReader) |
| **Security** | SHA-256 Password Hashing |
| **IDE** | Visual Studio |

---

## Project Structure

```
CMS/
├── CMSData/                          # Data Access Layer
│   ├── clsDataAccessSettings.cs      # Connection string configuration
│   ├── clsPersonsData.cs
│   ├── clsPatientsData.cs
│   ├── clsDoctorsData.cs
│   ├── clsUsersData.cs
│   ├── clsAppointmentsData.cs
│   ├── clsVisitsData.cs
│   ├── clsPrescriptionData.cs
│   ├── clsPrescriptionDetailsData.cs
│   ├── clsInvoicesData.cs
│   ├── clsInvoiceDetailsData.cs
│   ├── clsMedicalServicesData.cs
│   ├── clsMedicinesData.cs
│   ├── clsInsuranceCompaniesData.cs
│   ├── clsSpecialtiesData.cs
│   ├── clsRolesData.cs
│   └── clsDoctorScheduleData.cs
│
├── CMSLogic/                         # Business Logic Layer
│   ├── clsPerson.cs
│   ├── clsPatient.cs
│   ├── clsDoctor.cs
│   ├── clsUser.cs
│   ├── clsRole.cs
│   ├── clsAppointment.cs
│   ├── clsVisit.cs
│   ├── clsPrescription.cs
│   ├── clsPrescriptionDetails.cs
│   ├── clsInvoice.cs
│   ├── clsInvoiceDetails.cs
│   ├── clsMedicalService.cs
│   ├── clsMedicine.cs
│   ├── clsInsuranceCompany.cs
│   ├── clsSpecialty.cs
│   └── clsDoctorSchedule.cs
│
└── CMS_UI/                           # Presentation Layer
    ├── Global/
    │   ├── clsCurrentUser.cs
    │   ├── clsPasswordHasher.cs
    │   ├── clsRegistry.cs
    │   └── clsValidate.cs
    ├── Controls/
    │   ├── ctrlPerson.cs
    │   ├── ctrlPersonCard.cs
    │   └── ctrlUserCard.cs
    ├── Patients/
    │   ├── ManagePatients.cs
    │   ├── AddEditPatient.cs
    │   └── PatientInfo.cs
    ├── Doctors/
    │   ├── ManageDoctors.cs
    │   ├── AddEditDoctor.cs
    │   ├── DoctorInfo.cs
    │   └── ManageDoctorSchedule.cs
    ├── Appointments/
    │   ├── ManageAppointments.cs
    │   ├── AddEditAppointment.cs
    │   └── AppointmentDetails.cs
    ├── Visits/
    │   ├── ManageVisits.cs
    │   ├── StartVisit.cs
    │   └── VisitInfo.cs
    ├── Invoices/
    │   ├── ManageInvoices.cs
    │   └── AddEditInvoice.cs
    ├── InsuranceCompanies/
    │   ├── ManageInsuranceCompanies.cs
    │   └── AddEditInsuranceCompany.cs
    ├── Specialties/
    │   ├── ManageSpecialties.cs
    │   ├── AddEditSpecialty.cs
    │   └── SpecialtyInfo.cs
    ├── Users/
    │   ├── ManageUsers.cs
    │   ├── AddEditUser.cs
    │   └── UserInfo.cs
    ├── AdminDashboard.cs
    └── LogIn.cs
```

---

## Database Design

The SQL Server database uses a relational schema with the following core tables:

- **Persons** – Base entity for all people (patients, doctors, users)
- **Patients** – Medical-specific patient data
- **Doctors** – Doctor profiles linked to specialties
- **Users** – System users with roles and credentials
- **Roles** – Administrator, Receptionist, Doctor
- **Specialties** – Medical departments/specializations
- **Appointments** – Scheduled patient-doctor meetings
- **Visits** – Actual medical encounter records
- **Prescriptions** – Visit-linked prescriptions
- **PrescriptionDetails** – Individual medications per prescription
- **Invoices** – Billing records with insurance calculations
- **InvoiceDetails** – Line items per invoice
- **MedicalServices** – Available clinic services with pricing
- **Medicines** – Drug catalog
- **InsuranceCompanies** – Third-party insurance providers
- **DoctorSchedules** – Weekly availability per doctor

> **Note**: All heavy data operations are implemented via **SQL Server Stored Procedures** (prefix: `SP_`) to ensure security and performance.

---

## Getting Started

### Prerequisites

- Windows 10/11
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Microsoft SQL Server (Express or higher)
- SQL Server Management Studio (SSMS) – recommended

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/clinic-management-system.git
   cd clinic-management-system
   ```

2. **Restore the Database**
   - Open SSMS and connect to your SQL Server instance.
   - Run the provided SQL script `Database/CMS_Database.sql` to create the database, tables, and stored procedures.
   - Ensure the `CMS` database is created successfully.

3. **Update Connection String**
   - Open `CMSData/clsDataAccessSettings.cs`
   - Modify the connection string to match your SQL Server instance:
     ```csharp
     public static string ConnectionString = "Server=YOUR_SERVER;Database=CMS;User Id=sa;Password=YOUR_PASSWORD;";
     ```

4. **Build and Run**
   - Open `CMS.sln` in Visual Studio.
   - Restore NuGet packages if prompted.
   - Set `CMS_UI` as the startup project.
   - Press **F5** to run.

### Default Login

After database setup, create your first user via the database or use the user management module after logging in as a default administrator (if seeded).

---

## User Roles & Permissions

| Module | Administrator | Receptionist | Doctor |
|--------|:-------------:|:------------:|:------:|
| Dashboard | ✅ | ✅ | ✅ |
| Patients | ✅ | ✅ | View Only |
| Doctors | ✅ | ❌ | ❌ |
| Appointments | ✅ | ✅ | ✅ |
| Visits | ✅ | ❌ | ✅ |
| Prescriptions | ✅ | ❌ | ✅ |
| Invoices | ✅ | ✅ | ❌ |
| Insurance Companies | ✅ | ❌ | ❌ |
| Specialties | ✅ | ❌ | ❌ |
| Users | ✅ | ❌ | ❌ |

---

## Key Highlights

- **Consistent Domain Pattern**: Every entity follows the same `Find()` / `Save()` / `Delete()` pattern with an `enMode` state machine.
- **Real-time Validation**: WinForms `Validating` events enforce business rules at the UI level (email format, mandatory fields, uniqueness checks).
- **Appointment Conflict Detection**: Prevents double-booking doctors at the same time slot.
- **Insurance Auto-Calculation**: Automatically computes patient share vs. insurance coverage during invoicing.
- **Cascading Data Loading**: Business objects auto-load related entities (e.g., `clsAppointment` loads `PatientInfo`, `DoctorInfo`, and `InvoiceInfo` on instantiation).

---

## Future Improvements

- [ ] Migrate from SHA-256 to **bcrypt/Argon2** for password hashing
- [ ] Implement **database transactions** (`TransactionScope`) for multi-step operations (e.g., Doctor → User → Person saves)
- [ ] Replace hardcoded connection string with **encrypted configuration** (`app.config` / `secrets.json`)
- [ ] Add **Unit Tests** (MSTest or NUnit) for the Business Logic layer
- [ ] Implement **Dependency Injection** (e.g., using SimpleInjector or built-in DI)
- [ ] Optimize N+1 query issues by introducing **eager loading** methods with SQL JOINs
- [ ] Add **audit logging** for sensitive operations (delete, status changes)
- [ ] Export invoices and reports to **PDF/Excel**
- [ ] Migrate UI layer to **WPF or Blazor** for modern interface design

---

## License

This project is open-source and available for educational and personal use.

---

## Author

Developed as a learning project to practice N-Tier architecture, WinForms development, and database design principles.

---

> **Disclaimer**: This is a learning project. Before deploying in a real clinical environment, ensure all security, privacy (HIPAA/GDPR), and regulatory requirements are fully implemented and audited by professionals.
