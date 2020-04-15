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
            }
        
        }
    }
}
