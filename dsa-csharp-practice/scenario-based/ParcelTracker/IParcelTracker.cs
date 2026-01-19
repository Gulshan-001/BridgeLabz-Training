public interface IParcelTracker
{
    void AddStage(string stageName);
    void AddCheckpointAfter(string existingStage, string newStage);
    void DisplayTracking();
    void RemoveStage(string stageName);
}
