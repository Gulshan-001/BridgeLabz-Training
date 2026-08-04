use HospitalDB;
Go

CREATE TABLE AuditLog
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    TableName NVARCHAR(50) NOT NULL,
    OperationType NVARCHAR(10) NOT NULL,
    RecordID INT NOT NULL,
    OldValues NVARCHAR(MAX),
    NewValues NVARCHAR(MAX)
);
GO


-- Insert
INSERT INTO Doctor (FirstName, LastName, Specialization, Phone)
VALUES ('Aman', 'Singh', 'Dermatologist', '9876543210');

-- Update
UPDATE Doctor
SET Phone = '9999999999'
WHERE DoctorID = 1;

-- Delete
DELETE FROM Doctor
WHERE DoctorID = 1;

-- View Audit Log
SELECT * FROM AuditLog;


INSERT INTO Doctor (FirstName, LastName, Specialization, Phone)
VALUES
('Aarav', 'Sharma', 'Cardiologist', '9876543210'),
('Priya', 'Verma', 'Dermatologist', '9876543211'),
('Rohan', 'Mehta', 'Orthopedic', '9876543212'),
('Sneha', 'Patel', 'Neurologist', '9876543213'),
('Vikram', 'Singh', 'Pediatrician', '9876543214'),
('Ananya', 'Gupta', 'Gynecologist', '9876543215'),
('Karan', 'Malhotra', 'Psychiatrist', '9876543216'),
('Neha', 'Kapoor', 'ENT Specialist', '9876543217'),
('Aditya', 'Joshi', 'General Physician', '9876543218'),
('Ishita', 'Nair', 'Ophthalmologist', '9876543219');
go

DROP TRIGGER IF EXISTS TR_Doctor_Audit;
GO

CREATE TRIGGER TR_Doctor_Audit
ON Doctor
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    
    -- INSERT
    IF EXISTS (SELECT * FROM inserted)
       AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Doctor',
            'INSERT',
            DoctorID,
            NULL,
            CONCAT(FirstName, ' ', LastName, ', ', Specialization, ', ', Phone)
        FROM inserted;

        PRINT 'Doctor added successfully.';
    END

    -- DELETE
    IF EXISTS (SELECT * FROM deleted)
       AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Doctor',
            'DELETE',
            DoctorID,
            CONCAT(FirstName, ' ', LastName, ', ', Specialization, ', ', Phone),
            NULL
        FROM deleted;

        PRINT 'Doctor deleted successfully.';
    END

    -- UPDATE
    IF EXISTS (SELECT * FROM inserted)
       AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Doctor',
            'UPDATE',
            i.DoctorID,
            CONCAT(d.FirstName, ' ', d.LastName, ', ', d.Specialization, ', ', d.Phone),
            CONCAT(i.FirstName, ' ', i.LastName, ', ', i.Specialization, ', ', i.Phone)
        FROM inserted i
        INNER JOIN deleted d
            ON i.DoctorID = d.DoctorID;

        PRINT 'Doctor updated successfully.';
    END
END;
GO

CREATE TRIGGER TR_Patient_Audit
ON Patient
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    IF EXISTS (SELECT * FROM inserted)
       AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Patient',
            'INSERT',
            PatientID,
            NULL,
            CONCAT(FirstName, ' ', LastName, ', ', Gender, ', ', Phone, ', ', Address)
        FROM inserted;

        PRINT 'Patient added successfully.';
    END

    -- DELETE
    IF EXISTS (SELECT * FROM deleted)
       AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Patient',
            'DELETE',
            PatientID,
            CONCAT(FirstName, ' ', LastName, ', ', Gender, ', ', Phone, ', ', Address),
            NULL
        FROM deleted;

        PRINT 'Patient deleted successfully.';
    END

    -- UPDATE
    IF EXISTS (SELECT * FROM inserted)
       AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Patient',
            'UPDATE',
            i.PatientID,
            CONCAT(d.FirstName, ' ', d.LastName, ', ', d.Gender, ', ', d.Phone, ', ', d.Address),
            CONCAT(i.FirstName, ' ', i.LastName, ', ', i.Gender, ', ', i.Phone, ', ', i.Address)
        FROM inserted i
        INNER JOIN deleted d
            ON i.PatientID = d.PatientID;

        PRINT 'Patient updated successfully.';
    END
END;
GO

INSERT INTO Patient
(FirstName, LastName, DateOfBirth, Gender, Phone, Address)
VALUES
('Rahul', 'Sharma', '2002-05-15', 'M', '9876543000', 'Mathura');

UPDATE Patient
SET Address = 'Delhi'
WHERE PatientID = 1;

DELETE FROM Patient
WHERE PatientID = 1;

SELECT * FROM AuditLog;
go

--appointments trigger
CREATE TRIGGER TR_Appointment_Audit
ON Appointment
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    IF EXISTS (SELECT * FROM inserted)
       AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Appointment',
            'INSERT',
            AppointmentID,
            NULL,
            CONCAT(
                'PatientID=', PatientID,
                ', DoctorID=', DoctorID,
                ', Date=', AppointmentDate,
                ', Time=', TimeSlot,
                ', Status=', Status
            )
        FROM inserted;

        PRINT 'Appointment added successfully.';
    END

    -- DELETE
    IF EXISTS (SELECT * FROM deleted)
       AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Appointment',
            'DELETE',
            AppointmentID,
            CONCAT(
                'PatientID=', PatientID,
                ', DoctorID=', DoctorID,
                ', Date=', AppointmentDate,
                ', Time=', TimeSlot,
                ', Status=', Status
            ),
            NULL
        FROM deleted;

        PRINT 'Appointment deleted successfully.';
    END

    -- UPDATE
    IF EXISTS (SELECT * FROM inserted)
       AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AuditLog
        (
            TableName,
            OperationType,
            RecordID,
            OldValues,
            NewValues
        )
        SELECT
            'Appointment',
            'UPDATE',
            i.AppointmentID,
            CONCAT(
                'PatientID=', d.PatientID,
                ', DoctorID=', d.DoctorID,
                ', Date=', d.AppointmentDate,
                ', Time=', d.TimeSlot,
                ', Status=', d.Status
            ),
            CONCAT(
                'PatientID=', i.PatientID,
                ', DoctorID=', i.DoctorID,
                ', Date=', i.AppointmentDate,
                ', Time=', i.TimeSlot,
                ', Status=', i.Status
            )
        FROM inserted i
        INNER JOIN deleted d
            ON i.AppointmentID = d.AppointmentID;

        PRINT 'Appointment updated successfully.';
    END
END;
GO

INSERT INTO Appointment
(PatientID, DoctorID, AppointmentDate, TimeSlot, Status)
VALUES
(2, 2, '2026-08-10', '10:00:00', 'Scheduled');


INSERT INTO Patient
(FirstName, LastName, DateOfBirth, Gender, Phone, Address)
VALUES
('Rahul', 'Sharma', '2002-05-15', 'M', '9876500001', 'Delhi'),
('Priya', 'Verma', '1999-08-21', 'F', '9876500002', 'Mumbai'),
('Aman', 'Singh', '2001-03-10', 'M', '9876500003', 'Lucknow'),
('Sneha', 'Patel', '2000-11-05', 'F', '9876500004', 'Ahmedabad'),
('Rohan', 'Mehta', '1998-07-18', 'M', '9876500005', 'Jaipur'),
('Neha', 'Gupta', '2003-01-27', 'F', '9876500006', 'Noida'),
('Vikram', 'Joshi', '1997-09-12', 'M', '9876500007', 'Pune'),
('Ananya', 'Kapoor', '2002-12-30', 'F', '9876500008', 'Chandigarh'),
('Karan', 'Malhotra', '2001-06-09', 'M', '9876500009', 'Bhopal'),
('Ishita', 'Nair', '2000-04-14', 'F', '9876500010', 'Kochi');

UPDATE Appointment
SET Status = 'Completed'
WHERE AppointmentID = 4;

DELETE FROM Appointment
WHERE AppointmentID = 4;
go

select * from AuditLog;
go

CREATE PROCEDURE sp_AddDoctor
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Specialization NVARCHAR(100),
    @Phone NVARCHAR(15)
AS
BEGIN
    INSERT INTO Doctor
    (
        FirstName,
        LastName,
        Specialization,
        Phone
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @Specialization,
        @Phone
    );

    PRINT 'Doctor added successfully.';
END;
GO

CREATE PROCEDURE sp_UpdateDoctor
    @DoctorID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Specialization NVARCHAR(100),
    @Phone NVARCHAR(15)
AS
BEGIN
    UPDATE Doctor
    SET
        FirstName = @FirstName,
        LastName = @LastName,
        Specialization = @Specialization,
        Phone = @Phone
    WHERE DoctorID = @DoctorID;

    PRINT 'Doctor updated successfully.';
END;
GO

CREATE PROCEDURE sp_DeleteDoctor
    @DoctorID INT
AS
BEGIN
    DELETE FROM Doctor
    WHERE DoctorID = @DoctorID;

    PRINT 'Doctor deleted successfully.';
END;
GO

EXEC sp_AddDoctor
    @FirstName = 'Rakesh',
    @LastName = 'Kumar',
    @Specialization = 'Orthopedic',
    @Phone = '9876511111';

EXEC sp_DeleteDoctor
    @DoctorID = 13;