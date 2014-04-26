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
        public SQLiteConnection m_connection = new SQLiteConnection("Data Source=ClientDatabase.sqlite;Version=3;");

        public void GenerateSQLDatabase()
        {
            using ( var con = m_connection )
            using ( var cmd = new SQLiteCommand() )
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CREATE TABLE `Clients` ( `ClientId` INT UNSIGNED NOT NULL, `FirstName` VARCHAR(15) NOT NULL, `LastName` VARCHAR(15) NOT NULL, `Phone` VARCHAR(20) NOT NULL, `Company` VARCHAR(25) NOT NULL, PRIMARY KEY (`ClientId`) );";
                cmd.ExecuteNonQuery();
                //con.Close();
            }
        }

        public void AddClient(string id, string fname, string lname, string phone, string company)
        {
            using (SQLiteConnection con = m_connection)
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
                    //con.Close();
                }
            }
        }

        public List<Client> LoadClientList()
        {
            List<Client> tempList = new List<Client>();

            using (SQLiteConnection con = m_connection)
            {
                con.Open();
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clients";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //create client object with reader
                        Client tempClient = new Client((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4]);
                        tempList.Add(tempClient);
                    }
                }
            }

            return tempList;
        }
    }
}
