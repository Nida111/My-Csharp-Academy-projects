namespace HabitLogger.Domain;

public class UserHabit
{
    public int UserId { get; set; }
    public int HabitId { get; set; }
    public string OccuredOn { get; set; }
    public int Quantity { get; set; }
    public string? Unit { get; set; }

}