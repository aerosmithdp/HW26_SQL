using System.Data.SQLite;

namespace HW26_SQL
{
    public class SQL_Helper
    {
        public static SQLiteConnection Connect(string path)
        {
            string connection = path;
            SQLiteConnection database = new(connection);
            database.Open();
            return database;
        }

        public static SQLiteCommand Command(SQLiteConnection database, string query)
        {
            SQLiteCommand command = database.CreateCommand();
            command.CommandText = query;
            return command;
        }

        public static void Close(SQLiteConnection database) => database.Close();

    }
}
