class OutPatient : Patient, IPayable
{
    public double ConsultationFee;

    public OutPatient(int id, string name, double fee)
        : base(id, name)
    {
        ConsultationFee = fee;
    }

    public double CalculateBill()
    {
        return ConsultationFee;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Type: Out-Patient");
        Console.WriteLine("Bill: " + CalculateBill());
    }
}
