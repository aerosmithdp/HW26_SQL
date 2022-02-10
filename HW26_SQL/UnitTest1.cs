using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Xunit;

namespace HW26_SQL
{
    public class DB_Tests
    {

        [Fact]
        public void Test1CheckOwnerID()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT owner_id FROM Owners WHERE keyboard_id = (SELECT keyboard_id FROM Keyboards WHERE switch_id = 2)");
            var obj = command.ExecuteScalar();
            Assert.Equal(3, Convert.ToInt32(obj));
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test2CheckOwnerFullName()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT owner_fullname FROM Owners WHERE keyboard_id = (SELECT keyboard_id FROM Keyboards WHERE keyboard_name = 'Ducky One 2 TKL RGB White')");
            var obj = command.ExecuteScalar();
            Assert.Equal("Karl Torres", obj);
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test3CheckSwitchID()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT switch_id FROM Keyboards WHERE keyboard_id = (SELECT keyboard_id FROM Owners WHERE owner_id = 2)");
            var obj = command.ExecuteScalar();
            Assert.Equal(1, Convert.ToInt32(obj));
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test4CheckSwitchName()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT switch_name FROM Switches WHERE switch_id = (SELECT switch_id FROM Keyboards WHERE keyboard_id = 5)");
            var obj = command.ExecuteScalar();
            Assert.Equal("Cherry MX Red", obj);
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test5CheckSwitchType()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT switch_type FROM Switches WHERE switch_id = (SELECT switch_id FROM Keyboards WHERE keyboard_name = 'Leopold FC750R White Mint PD')");
            var obj = command.ExecuteScalar();
            Assert.Equal("Linear", obj);
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test6CheckKeyboardID()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT keyboard_id FROM Owners WHERE owner_id = (SELECT owner_id FROM Keyboards WHERE owner_fullname = 'Joel Simon')");
            var obj = command.ExecuteScalar();
            Assert.Equal(5, Convert.ToInt32(obj));
            SQL_Helper.Close(database);
        }

        [Fact]
        public void Test7CheckKeyboardName()
        {
            SQLiteConnection database = SQL_Helper.Connect(@"Data Source=C:/Users/User/Desktop/HW26_SQL/hw26database.db");
            SQLiteCommand command = SQL_Helper.Command(database, "SELECT keyboard_name FROM Keyboards WHERE keyboard_id = (SELECT keyboard_id FROM Owners WHERE owner_fullname = 'Nora Jackson')");
            var obj = command.ExecuteScalar();
            Assert.Equal("Ducky One 2 Phantom Black", obj);
            SQL_Helper.Close(database);

        }
        
    }
}
