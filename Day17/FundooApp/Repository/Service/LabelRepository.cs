using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Repository.Context;
using Repository.Interface;

namespace Repository.Service;

public class LabelRepository : ILabelRepository
{
    private readonly ApplicationDbContext _context;

    public LabelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Label> CreateLabelAsync(Label label)
    {
        _context.Labels.Add(label);

        await _context.SaveChangesAsync();

        return label;
    }

    public async Task<Label?> GetLabelByIdAsync(
        int labelId,
        int userId)
    {
        return await _context.Labels
            .FirstOrDefaultAsync(label =>
                label.Id == labelId &&
                label.UserId == userId);
    }

    public async Task<List<Label>> GetAllLabelsAsync(int userId)
    {
        return await _context.Labels
            .Where(label => label.UserId == userId)
            .ToListAsync();
    }

    public async Task<Label?> UpdateLabelAsync(Label label)
    {
        var existingLabel = await _context.Labels
            .FirstOrDefaultAsync(l =>
                l.Id == label.Id &&
                l.UserId == label.UserId);

        if (existingLabel == null)
        {
            return null;
        }

        existingLabel.Name = label.Name;

        await _context.SaveChangesAsync();

        return existingLabel;
    }

    public async Task<bool> DeleteLabelAsync(
        int labelId,
        int userId)
    {
        var label = await _context.Labels
            .FirstOrDefaultAsync(label =>
                label.Id == labelId &&
                label.UserId == userId);

        if (label == null)
        {
            return false;
        }

        _context.Labels.Remove(label);

        await _context.SaveChangesAsync();

        return true;
    }
}