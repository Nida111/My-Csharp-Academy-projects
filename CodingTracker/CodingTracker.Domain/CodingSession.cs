namespace CodingTracker.Domain;

public class CodingSession
{
    public required int UserId { get; set; }
    public required string OccuredDate { get; set; }
    public required string StartTime { get; set; }
    public required string EndTime { get; set; }
    public required string Duration { get; set; }
}