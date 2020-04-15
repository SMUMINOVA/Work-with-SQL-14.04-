using System;
using System.Data;
using System.Data.SqlClient;
namespace HW_15_04
{
    class Program
    {
        static void Main(string[] args)
        {
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            if(scon.State == ConnectionState.Open)
                System.Console.WriteLine("Connected successfully");
            else 
                System.Console.WriteLine("Oooops, some problems");
            
        }
        class SCommands{
            public int Id{get; set;}
            public string LastName{get; set;}
            public string FirstName {get; set;}
            public string MiddleName {get; set;}
            public string BirthDate{get; set;}
            public string key {get; set;}
            public string choiceKey{get; set;}
            
            public void insertSCommand(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"insert into Person([FirstName],[MiddleName],[LastName],[BirthDate]) Values('{FirstName}','{MiddleName}', '{LastName}', {BirthDate})");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Insert command successfull!!!");
                }
            }
            
            public void selectAllSCommand(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = "Select * from Person";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"ID:{reader.GetValue("Id")}, FirstName:{reader.GetValue("FirstName")},MiddleName:{reader.GetValue("MiddleName")}, LastName:{reader.GetValue("LastName")}, Date of Birth: {reader.GetValue("BirthDate")}");
                }
                reader.Close();
                }
            public void selectByIdSCommand(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Person where id = {Id}";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"ID:{reader.GetValue("Id")}, FirstName:{reader.GetValue("FirstName")},MiddleName:{reader.GetValue("MiddleName")}, LastName:{reader.GetValue("LastName")}, Date of Birth: {reader.GetValue("BirthDate")}");
                }
                reader.Close();
                }
            
            public void updateLastName(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"update Person set LastName = {LastName} where {choiceKey} = {key}");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Update command successfull!!!");
                }
            }
            public void updateMiddleName(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"update Person set MiddleName = {MiddleName} where {choiceKey} = {key}");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Update command successfull!!!");
                }
            }
            public void updateFirstName(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"update Person set FirstleName = {FirstName} where {choiceKey} = {key}");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Update command successfull!!!");
                }
            }
            public void updateBirthDate(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"update Person set BirthDate = {BirthDate} where {choiceKey} = {key}");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Update command successfull!!!");
                }
            }
            public void Delete(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string insertSqlCommand = string.Format($"delete Person where {choiceKey} = {key}");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    System.Console.WriteLine("Delete command successfull!!!");
                }
            }
        }
    }
}
