using Models.DTO;

namespace Business.Interface;

public interface ILabelService
{
    Task<LabelResponseDTO> CreateLabelAsync(
        CreateLabelRequestDTO request,
        int userId);

    Task<LabelResponseDTO?> GetLabelByIdAsync(
        int labelId,
        int userId);

    Task<List<LabelResponseDTO>> GetAllLabelsAsync(
        int userId);

    Task<LabelResponseDTO?> UpdateLabelAsync(
        int labelId,
        UpdateLabelRequestDTO request,
        int userId);

    Task<bool> DeleteLabelAsync(
        int labelId,
        int userId);
}