using System;
using System.Data.SqlClient;

namespace SqlServerSample;

class Program
{
    static void Main(string[] args)
    {
        // string connectionString = "Server=buudi\\SQLEXPRESS;Database=MyBootcamp;Trusted_Connection=true"; // Home PC
        // string connectionString = "Server=BITLAB-001\\SQLEXPRESS;Database=MyBootcamp;Trusted_Connection=True;"; Work Laptop
        
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=MyBootcamp;Trusted_Connection=True;"; // Using Local Host


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");

                string query = "SELECT * FROM Person";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["id"]}, Name: {reader["name"]}, Created: {reader["CreateDateTime"]}");
                    // Console.WriteLine($"{reader["name"]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}
