using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

//this file is rather repetitive, redesign when most of the program is ready
namespace Freelancr
{
    class DatabaseConnector
    {
        public void GenerateSQLDatabase()
        {
            using (var con = new SQLiteConnection("Data Source=ClientDatabase.sqlite;Version=3;"))
            using ( var cmd = new SQLiteCommand() )
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CREATE TABLE `Clients` ( `ClientId` INT UNSIGNED NOT NULL, `FirstName` VARCHAR(15) NOT NULL, `LastName` VARCHAR(15) NOT NULL, `Phone` VARCHAR(20) NOT NULL, `Company` VARCHAR(25) NOT NULL, PRIMARY KEY (`ClientId`) );";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void AddClient(int id, string fname, string lname, string phone, string company)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=ClientDatabase.sqlite;Version=3;"))
            {
                try
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO `Clients` VALUES( @Id, @FirstName, @LastName, @Phone, @Business);";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@FirstName", fname);
                        cmd.Parameters.AddWithValue("@LastName", lname);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Business", company);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                }
            }
        }

        public Dictionary<int, Client> LoadClientList()
        {
            Dictionary<int, Client> tempDictionary = new Dictionary<int, Client>();

            using (SQLiteConnection con = new SQLiteConnection("Data Source=ClientDatabase.sqlite;Version=3;"))
            {
                con.Open();
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clients";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //create client object with reader
                        Client tempClient = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        tempDictionary.Add(reader.GetInt32(0), tempClient);
                    }
                    con.Close();
                }
            }

            return tempDictionary;
        }
    }
}
