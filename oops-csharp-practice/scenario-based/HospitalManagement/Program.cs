using System;

class Program
{
    static void Main()
    {
        Patient p1 = new InPatient(1, "Aman", 5, 2000);
        Patient p2 = new OutPatient(2, "Riya", 500);

        Doctor d1 = new Doctor("Dr. Sharma", "Cardiology");

        d1.DisplayDoctor();
        Console.WriteLine();

        p1.DisplayInfo();
        Console.WriteLine();

        p2.DisplayInfo();
    }
}