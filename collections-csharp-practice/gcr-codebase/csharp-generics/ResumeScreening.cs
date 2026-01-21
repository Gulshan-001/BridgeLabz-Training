using System;
using System.Collections.Generic;

// ---------- BASE JOB ROLE ----------
abstract class JobRole
{
    public string RoleName { get; protected set; }

    // each role evaluates resume differently
    public abstract void EvaluateResume(string candidateName);
}

// ---------- JOB ROLES ----------
class SoftwareEngineer : JobRole
{
    public SoftwareEngineer()
    {
        RoleName = "Software Engineer";
    }

    public override void EvaluateResume(string candidateName)
    {
        Console.WriteLine(candidateName + " evaluated for coding and problem-solving skills.");
    }
}

class DataScientist : JobRole
{
    public DataScientist()
    {
        RoleName = "Data Scientist";
    }

    public override void EvaluateResume(string candidateName)
    {
        Console.WriteLine(candidateName + " evaluated for data analysis and ML skills.");
    }
}

// ---------- GENERIC RESUME CLASS ----------
class Resume<T> where T : JobRole
{
    private List<T> jobRoles = new List<T>();

    public void AddJobRole(T role)
    {
        jobRoles.Add(role);
    }

    public void ScreenResume(string candidateName)
    {
        Console.WriteLine("\nScreening resume for: " + candidateName);

        foreach (T role in jobRoles)
        {
            Console.WriteLine("Job Role: " + role.RoleName);
            role.EvaluateResume(candidateName);
        }
    }
}

// ---------- PROGRAM ----------
class Program
{
    static void Main()
    {
        // create resume screening pipelines
        Resume<SoftwareEngineer> seResume = new Resume<SoftwareEngineer>();
        seResume.AddJobRole(new SoftwareEngineer());

        Resume<DataScientist> dsResume = new Resume<DataScientist>();
        dsResume.AddJobRole(new DataScientist());

        // screen candidates
        seResume.ScreenResume("Amit");
        dsResume.ScreenResume("Neha");
    }
}