using Microsoft.Data.Sqlite;

namespace HabitLogger.Infrastructure;

public class DatabaseInitializer
{
    public void CreateDatabase()
    {
        // establish a connection with the db, it creates a database if it isn't present 
        using var connection = new SqliteConnection("Data Source=habit.db");
        connection.Open();
        
        //now we will create a user table
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = """
                              CREATE Table IF NOT EXISTS User (
                                ID integer primary key,
                                Name TEXT NOT NULL UNIQUE
                              );
                              
                              CREATE Table IF NOT EXISTS Habit (
                              ID Integer primary key,
                              Name TEXT NOT NULL UNIQUE
                              );
                              
                              CREATE Table IF NOT EXISTS UserHabit (
                              UserID Integer not null, 
                              HabitID Integer not null,
                              OccuredOn Text not null,
                              Quantity Integer not null,
                              Unit Text not null,
                              FOREIGN KEY(UserID)  REFERENCES User(ID),
                              FOREIGN KEY(HabitID) REFERENCES Habit(ID),     
                              PRIMARY KEY ( UserID, HabitID,OccuredOn)                       
                              );
                              """;
        
        command.ExecuteNonQuery();
    } 
}