using HabitLogger.Domain;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Infrastructure.Data.Repositories;

public class UserHabitRepository
{
    public void Insert(UserHabit userHabit)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        string sql = "INSERT INTO UserHabit(UserID, HabitID,OccuredOn, Quantity, Unit) VALUES (@UserId, @HabitId, @OccuredOn, @Quantity, @Unit);";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userHabit.UserId);
        cmd.Parameters.AddWithValue("@HabitId", userHabit.HabitId);
        cmd.Parameters.AddWithValue("@OccuredOn", userHabit.OccuredOn);
        cmd.Parameters.AddWithValue("@Quantity", userHabit.Quantity);
        cmd.Parameters.AddWithValue("@Unit", userHabit.Unit);
        cmd.ExecuteNonQuery();
    }
    
    
    public List<UserHabit> GetAllUserId(int userId) 
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        // Query to look for username
        string sql = $"SELECT * FROM UserHabit WHERE UserId ={userId}";
        using var cmd = new SqliteCommand(sql, connection);
        using SqliteDataReader dataReader = cmd.ExecuteReader();  // lets you read results one row at a time:
        List<UserHabit> userHabits = new List<UserHabit>();
        while (dataReader.Read())
        {
            
            userHabits.Add(new UserHabit {
                UserId = dataReader.GetInt32(0),
                HabitId = dataReader.GetInt32(1),
                OccuredOn = dataReader.GetString(2),
                Quantity = dataReader.GetInt32(3),
                Unit = dataReader.GetString(4),
                
            });
            
        }
        return userHabits;
    }
    
    public void Delete(int userId, int habitId, string occuredDate)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        string sql = "DELETE FROM UserHabit WHERE UserID = @UserId AND  HabitID = @HabitId AND  OccuredOn = @OccuredOn;";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userId);
        cmd.Parameters.AddWithValue("@HabitId", habitId);
        cmd.Parameters.AddWithValue("@OccuredOn", occuredDate);
        cmd.ExecuteNonQuery();
        
    }
    
    
    public void Update(UserHabit userHabit, string? updatedDate, int updatedQuantity, string? updatedUnit)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        string sql ="UPDATE UserHabit SET OccuredOn = @newOccuredOn, Quantity = @newQuantity, Unit = @newUnit WHERE UserID = @UserId AND HabitID = @HabitId AND OccuredOn = @oldOccuredOn";
            
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userHabit.UserId);
        cmd.Parameters.AddWithValue("@HabitId", userHabit.HabitId);
        cmd.Parameters.AddWithValue("@oldOccuredOn", userHabit.OccuredOn);
        cmd.Parameters.AddWithValue("@newOccuredOn", updatedDate);
        cmd.Parameters.AddWithValue("@newQuantity", updatedQuantity);
        cmd.Parameters.AddWithValue("@newUnit", updatedUnit);
        cmd.ExecuteNonQuery();
    }
}