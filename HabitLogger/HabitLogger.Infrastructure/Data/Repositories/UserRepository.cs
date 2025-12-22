namespace HabitLogger.Infrastructure.Data.Repositories;
using Microsoft.Data.Sqlite;
using HabitLogger.Domain;
public class UserRepository 
{
    public void Insert(User user)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        string sql = "INSERT INTO User(Name) VALUES (@Name)";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Name", user.Name);
        cmd.ExecuteNonQuery();
    }

   /// <summary>
   ///  Checks if a user exists by name. 
   /// </summary>
   /// <param name="name">Name of the user</param>
   /// <returns>Returns user if it exists, else returns null</returns>
    public User? GetByName(string name)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        // Query to look for username
        string sql = "SELECT * FROM User WHERE Name = @Name;";
        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Name", name);
        using SqliteDataReader dataReader = cmd.ExecuteReader();        // lets you read results one row at a time:
        
        if (dataReader.Read())                                          // check if datareader returns something or not
        { 
            User user = new User();
            user.Id = Convert.ToInt32(dataReader["Id"]);
            user.Name = dataReader["Name"].ToString();
            return user;
        }
        return null;
    }

    public User? GetById(int id)
    {
        //Establish a connection with the database
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        // Query to look for username
        string sql = $"SELECT * FROM User WHERE Id = {id};";
        using var cmd = new SqliteCommand(sql, connection);
        using SqliteDataReader DataReader = cmd.ExecuteReader(); // lets you read results one row at a time:
        // check if datareader returns something or not
        if (DataReader.Read())
        { 
            User user = new User();
            user.Id = Convert.ToInt32(DataReader["Id"]);
            user.Name = DataReader["Name"].ToString();
            return user;
        }
        return null;
    }
}