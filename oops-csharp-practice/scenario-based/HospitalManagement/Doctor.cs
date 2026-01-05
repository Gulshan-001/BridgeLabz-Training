class Doctor
{
    public string DoctorName;
    public string Specialization;

    public Doctor(string name, string specialization)
    {
        DoctorName = name;
        Specialization = specialization;
    }

    public void DisplayDoctor()
    {
        Console.WriteLine("Doctor: " + DoctorName);
        Console.WriteLine("Specialization: " + Specialization);
    }
}
