using HabitLogger.Domain;
using Microsoft.Data.Sqlite;

namespace HabitLogger.Infrastructure.Data.Repositories;

public class HabitRepository
{
    public void Insert(Habit habit) 
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        string sql = "INSERT INTO Habit(Name) VALUES (@Name);";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Name", habit.Name);
        cmd.ExecuteNonQuery();
    }

    public Habit? GetByName(string name)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        // Query to look for username
        string sql = "SELECT * FROM Habit WHERE Name = @Name;";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Name", name);
        using SqliteDataReader dataReader = cmd.ExecuteReader();        // lets you read results one row at a time:
        
        if (dataReader.Read())                                          // check if datareader returns something or not
        { 
            Habit habit = new Habit();
            habit.Id = Convert.ToInt32(dataReader["Id"]);
            habit.Name = dataReader["Name"].ToString();
            return habit;
        }
        return null;
    }
    
    public string? GetById(int habitId)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        // Query to look for username
        string sql = $"SELECT * FROM Habit WHERE ID = {habitId};";
        using var cmd = new SqliteCommand(sql, connection);
        using SqliteDataReader dataReader = cmd.ExecuteReader(); // lets you read results one row at a time:
        // check if datareader returns something or not
        if (dataReader.Read())
        { 
            var name = dataReader["Name"].ToString();
            return name;
        }

        return null;
    }
    
    
}