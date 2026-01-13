// Interface for loan approval and EMI calculation
interface IApprovable
{
    bool ApproveLoan();
    double CalculateEMI();
}
