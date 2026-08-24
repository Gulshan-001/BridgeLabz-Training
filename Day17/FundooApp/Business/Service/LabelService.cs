using Business.Interface;
using Models.DTO;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class LabelService : ILabelService
{
    private readonly ILabelRepository _labelRepository;

    public LabelService(ILabelRepository labelRepository)
    {
        _labelRepository = labelRepository;
    }

    public async Task<LabelResponseDTO> CreateLabelAsync(
        CreateLabelRequestDTO request,
        int userId)
    {
        var label = new Label
        {
            Name = request.Name,
            UserId = userId
        };

        var createdLabel = await _labelRepository
            .CreateLabelAsync(label);

        return MapToResponse(createdLabel);
    }

    public async Task<LabelResponseDTO?> GetLabelByIdAsync(
        int labelId,
        int userId)
    {
        var label = await _labelRepository
            .GetLabelByIdAsync(labelId, userId);

        return label == null ? null : MapToResponse(label);
    }

    public async Task<List<LabelResponseDTO>> GetAllLabelsAsync(
        int userId)
    {
        var labels = await _labelRepository
            .GetAllLabelsAsync(userId);

        return labels
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<LabelResponseDTO?> UpdateLabelAsync(
        int labelId,
        UpdateLabelRequestDTO request,
        int userId)
    {
        var label = new Label
        {
            Id = labelId,
            Name = request.Name,
            UserId = userId
        };

        var updatedLabel = await _labelRepository
            .UpdateLabelAsync(label);

        return updatedLabel == null
            ? null
            : MapToResponse(updatedLabel);
    }

    public async Task<bool> DeleteLabelAsync(
        int labelId,
        int userId)
    {
        return await _labelRepository
            .DeleteLabelAsync(labelId, userId);
    }

    private static LabelResponseDTO MapToResponse(Label label)
    {
        return new LabelResponseDTO
        {
            Id = label.Id,
            Name = label.Name
        };
    }
}