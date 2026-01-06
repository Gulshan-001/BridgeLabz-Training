using System;

// interface for medical records
interface IMedicalRecord
{
    void AddRecord(string diagnosis);
    void ViewRecords();
}

// abstract class
abstract class Patient
{
    public int PatientId;
    public string Name;
    public int Age;

    // sensitive data (encapsulation)
    protected string medicalHistory;

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
        medicalHistory = "No records";
    }

    // abstract method
    public abstract double CalculateBill();

    // normal method
    public void GetPatientDetails()
    {
        Console.WriteLine("ID: " + PatientId);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

// InPatient class
class InPatient : Patient, IMedicalRecord
{
    private int daysAdmitted;

    public InPatient(int id, string name, int age, int days)
        : base(id, name, age)
    {
        daysAdmitted = days;
    }

    public override double CalculateBill()
    {
        return daysAdmitted * 2000; // basic charge
    }

    public void AddRecord(string diagnosis)
    {
        medicalHistory = diagnosis;
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical History: " + medicalHistory);
    }
}

// OutPatient class
class OutPatient : Patient, IMedicalRecord
{
    private int visitCount;

    public OutPatient(int id, string name, int age, int visits)
        : base(id, name, age)
    {
        visitCount = visits;
    }

    public override double CalculateBill()
    {
        return visitCount * 500; // consultation fee
    }

    public void AddRecord(string diagnosis)
    {
        medicalHistory = diagnosis;
    }

    public void ViewRecords()
    {
        Console.WriteLine("Medical History: " + medicalHistory);
    }
}

// main program
class Program
{
    static void Main()
    {
        // polymorphism
        Patient p1 = new InPatient(1, "Rahul", 30, 3);
        Patient p2 = new OutPatient(2, "Anita", 25, 2);

        IMedicalRecord r1 = (IMedicalRecord)p1;
        IMedicalRecord r2 = (IMedicalRecord)p2;

        r1.AddRecord("Fracture treatment");
        r2.AddRecord("Fever checkup");

        Console.WriteLine("---- In Patient ----");
        p1.GetPatientDetails();
        r1.ViewRecords();
        Console.WriteLine("Bill: ₹" + p1.CalculateBill());

        Console.WriteLine();

        Console.WriteLine("---- Out Patient ----");
        p2.GetPatientDetails();
        r2.ViewRecords();
        Console.WriteLine("Bill: ₹" + p2.CalculateBill());
    }
}
