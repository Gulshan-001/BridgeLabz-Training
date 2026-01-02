using System;
using System.Collections.Generic;

class Patient
{
    public string Name;
    public int Age;

    private List<Doctor> doctors;

    public Patient(string name, int age)
    {
        Name = name;
        Age = age;
        doctors = new List<Doctor>();
    }

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
    }

    public void ShowDoctors()
    {
        Console.WriteLine($"\n{this.Name}'s Doctors:");
        foreach (Doctor d in doctors)
        {
            Console.WriteLine($"- {d.Name}, {d.Specialization}");
        }
    }
}

class Doctor
{
    public string Name;
    public string Specialization;
    private List<Patient> patients;

    public Doctor(string name, string specialization)
    {
        Name = name;
        Specialization = specialization;
        patients = new List<Patient>();
    }

    // Association communication
    public void Consult(Patient patient)
    {
        patients.Add(patient);
        patient.AddDoctor(this);
        Console.WriteLine($"{Name} (Doctor) is consulting {patient.Name} (Patient)");
    }

    public void ShowPatients()
    {
        Console.WriteLine($"\nPatients of Dr. {Name}:");
        foreach (Patient p in patients)
        {
            Console.WriteLine($"- {p.Name}, Age {p.Age}");
        }
    }
}

class Hospital
{
    public string HospitalName;

    public Hospital(string name)
    {
        HospitalName = name;
    }
}

class Program
{
    static void Main()
    {
        // Doctors
        Doctor drSmith = new Doctor("Smith", "Cardiology");
        Doctor drJones = new Doctor("Jones", "Neurology");

        // Patients
        Patient alice = new Patient("Alice", 30);
        Patient bob = new Patient("Bob", 45);

        // Hospital exists independently
        Hospital cityHospital = new Hospital("City Hospital");

        // Association: Consultations
        drSmith.Consult(alice);
        drSmith.Consult(bob);

        drJones.Consult(alice);

        // Display consultations
        drSmith.ShowPatients();
        drJones.ShowPatients();

        alice.ShowDoctors();
        bob.ShowDoctors();
    }
}
