using System.Collections.Generic;

public interface ICreatorService
{
    void RegisterCreator(CreatorStats record);
    Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold);
    double CalculateAverageLikes();
}
