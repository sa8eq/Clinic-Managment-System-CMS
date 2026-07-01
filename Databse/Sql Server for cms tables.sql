CREATE TABLE Persons (
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    SecondName NVARCHAR(50),
    ThirdName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
    DateOfBirth DATE NOT NULL,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    Address NVARCHAR(250),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Specialties (
    SpecialtyID INT IDENTITY(1,1) PRIMARY KEY,
    SpecialtyName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(MAX)
);

CREATE TABLE Doctors (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    PersonID INT NOT NULL UNIQUE,            
    SpecialtyID INT NOT NULL,
    LicenseNumber NVARCHAR(50) NOT NULL UNIQUE,
    HireDate DATE NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
    FOREIGN KEY (SpecialtyID) REFERENCES Specialties(SpecialtyID)
);

CREATE TABLE InsuranceCompanies (
    InsuranceCompanyID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL UNIQUE,
    ContactPhone NVARCHAR(20),
    CoveragePercentage DECIMAL(5,2) NOT NULL CHECK (CoveragePercentage BETWEEN 0 AND 100)
);

CREATE TABLE Patients (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    PersonID INT NOT NULL UNIQUE,             
    BloodType VARCHAR(5) CHECK (BloodType IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')),
    InsuranceCompanyID INT NULL,
    InsurancePolicyNumber NVARCHAR(50) NULL,
    EmergencyContactPhone NVARCHAR(20),
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
    FOREIGN KEY (InsuranceCompanyID) REFERENCES InsuranceCompanies(InsuranceCompanyID)
);

CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,  
    PersonID INT NOT NULL UNIQUE,           
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE DoctorSchedules (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    DoctorID INT NOT NULL, 
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

CREATE TABLE Appointments (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL, 
    DoctorID INT NOT NULL,  
    AppointmentDate DATETIME NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Confirmed', 'Cancelled', 'Completed')),
    Notes NVARCHAR(500),
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

CREATE TABLE Visits (
    VisitID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentID INT NOT NULL,
    VisitDate DATETIME DEFAULT GETDATE(),
    Symptoms NVARCHAR(MAX),
    Diagnosis NVARCHAR(MAX),
    VitalSigns_BP VARCHAR(20),
    VitalSigns_Pulse INT,
    VitalSigns_Temp DECIMAL(4,1),
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
);

CREATE TABLE Medicines (
    MedicineID INT IDENTITY(1,1) PRIMARY KEY,
    MedicineName NVARCHAR(100) NOT NULL UNIQUE,
    ActiveIngredient NVARCHAR(100),
    Form NVARCHAR(50)
);

CREATE TABLE Prescriptions (
    PrescriptionID INT IDENTITY(1,1) PRIMARY KEY,
    VisitID INT NOT NULL UNIQUE,
    Notes NVARCHAR(500),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

CREATE TABLE PrescriptionDetails (
    PrescriptionDetailID INT IDENTITY(1,1) PRIMARY KEY,
    PrescriptionID INT NOT NULL,
    MedicineID INT NOT NULL,
    Dosage NVARCHAR(100) NOT NULL,
    Duration NVARCHAR(50) NOT NULL,
    FOREIGN KEY (PrescriptionID) REFERENCES Prescriptions(PrescriptionID),
    FOREIGN KEY (MedicineID) REFERENCES Medicines(MedicineID)
);

CREATE TABLE MedicalServices (
    ServiceID INT IDENTITY(1,1) PRIMARY KEY,
    ServiceName NVARCHAR(100) NOT NULL UNIQUE,
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    VisitID INT NOT NULL UNIQUE,
    InvoiceDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) DEFAULT 0.00,
    InsuranceCoveredAmount DECIMAL(10,2) DEFAULT 0.00,
    PatientShareAmount DECIMAL(10,2) DEFAULT 0.00,
    PaymentStatus NVARCHAR(20) DEFAULT 'Unpaid' CHECK (PaymentStatus IN ('Unpaid', 'Paid', 'Partially_Paid')),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

CREATE TABLE InvoiceDetails (
    InvoiceDetailID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    ServiceID INT NOT NULL,
    Quantity INT DEFAULT 1,
    Price DECIMAL(10,2) NOT NULL, 
    LineTotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    FOREIGN KEY (ServiceID) REFERENCES MedicalServices(ServiceID)
);