using Models.Entity;

namespace Repository.Interface;

public interface ILabelRepository
{
    Task<Label> CreateLabelAsync(Label label);

    Task<Label?> GetLabelByIdAsync(int labelId, int userId);

    Task<List<Label>> GetAllLabelsAsync(int userId);

    Task<Label?> UpdateLabelAsync(Label label);

    Task<bool> DeleteLabelAsync(int labelId, int userId);
}