class InPatient : Patient, IPayable
{
    public int DaysAdmitted;
    public double DailyCharge;

    public InPatient(int id, string name, int days, double charge)
        : base(id, name)
    {
        DaysAdmitted = days;
        DailyCharge = charge;
    }

    public double CalculateBill()
    {
        return DaysAdmitted * DailyCharge;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Type: In-Patient");
        Console.WriteLine("Bill: " + CalculateBill());
    }
}
