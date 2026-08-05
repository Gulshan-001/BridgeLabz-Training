namespace HealthClinicApp.Entity;

public class Doctor
{
    public int DoctorID { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Specialization { get; set; } = "";

    public string Phone { get; set; } = "";
}