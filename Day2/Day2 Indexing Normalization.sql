-- QUESTION 1
USE HospitalDB;
GO

-- Create Room table
CREATE TABLE Room
(
    RoomID INT IDENTITY(1,1),
    RoomNumber VARCHAR(10) NOT NULL,
    FloorNumber INT NOT NULL,

    CONSTRAINT PK_Room PRIMARY KEY (RoomID),
    CONSTRAINT UQ_Room_RoomNumber UNIQUE (RoomNumber)
);
GO

-- Create Doctor_Room table
CREATE TABLE Doctor_Room
(
    DoctorID INT NOT NULL,
    RoomID INT NOT NULL,

    CONSTRAINT PK_Doctor_Room PRIMARY KEY (DoctorID, RoomID),

    CONSTRAINT FK_DoctorRoom_Doctor
        FOREIGN KEY (DoctorID)
        REFERENCES Doctor(DoctorID),

    CONSTRAINT FK_DoctorRoom_Room
        FOREIGN KEY (RoomID)
        REFERENCES Room(RoomID)
);
GO

-- QUESTION 2
SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-03';
--singlecolumnindex
CREATE INDEX IX_Appointment_AppointmentDate
ON Appointment(AppointmentDate);
GO
SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-03';
--compositeindex
CREATE INDEX IX_Appointment_Date_Doctor
ON Appointment(AppointmentDate, DoctorID);
GO
SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-03'
AND DoctorID = 1;


--covering index ques4
CREATE INDEX IX_Appointment_Report
ON Appointment (DoctorID)
INCLUDE (AppointmentDate, Status);
GO

SELECT DoctorID,
       AppointmentDate,
       Status
FROM Appointment
WHERE DoctorID = 1;
GO