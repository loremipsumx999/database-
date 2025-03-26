using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //MYSQL KAPCSOLAT LÉTREHOZÁSA
            string connectionString = "server = localhost; user = root; database = registration_db; password = ";

            //Adatbázishoz kapcsolódás
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Sikeresen kapcsolódva a MySql adatbázishoz");

                    //Példa lekérdezéséhez
                    string query = "SELECT * FROM users";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID:{reader["id"]}, Felhasználónév: {reader["username"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt: {ex.Message}");
                }
            }
        }
    }
}