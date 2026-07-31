-- Create Database
CREATE DATABASE HospitalDB;
GO

-- Select Database
USE HospitalDB;
GO

-- Doctor Table

CREATE TABLE Doctor
(
    DoctorID INT IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),

    CONSTRAINT PK_Doctor PRIMARY KEY (DoctorID),
    CONSTRAINT UQ_DoctorPhone UNIQUE (Phone)
);
GO

-- Patient Table

CREATE TABLE Patient
(
    PatientID INT IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender CHAR(1),
    DateOfBirth DATE NOT NULL,
    Phone NVARCHAR(15),
    Address NVARCHAR(200),

    CONSTRAINT PK_Patient PRIMARY KEY (PatientID),
    CONSTRAINT UQ_PatientPhone UNIQUE (Phone),
    CONSTRAINT CHK_PatientGender CHECK (Gender IN ('M','F','O'))
);
GO

-- Appointment Table


CREATE TABLE Appointment
(
    AppointmentID INT IDENTITY(1,1),
    AppointmentDate DATE NOT NULL,
    TimeSlot TIME NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Scheduled',
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    CONSTRAINT PK_Appointment PRIMARY KEY (AppointmentID),

    CONSTRAINT FK_Appointment_Patient
        FOREIGN KEY (PatientID)
        REFERENCES Patient(PatientID)
        ON DELETE CASCADE,

    CONSTRAINT FK_Appointment_Doctor
        FOREIGN KEY (DoctorID)
        REFERENCES Doctor(DoctorID)
        ON DELETE CASCADE
);
GO