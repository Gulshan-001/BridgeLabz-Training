public interface IHospitalRoute
{
    void AddUnit(string unitName);
    void RemoveUnit(string unitName);
    void RedirectPatient();
    void DisplayRoute();
}