class Patient
{
    public int PatientId;
    public string Name;

    public Patient(int id, string name)
    {
        PatientId = id;
        Name = name;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Patient ID: " + PatientId);
        Console.WriteLine("Name: " + Name);
    }
}
