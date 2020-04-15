using System;
using System.Data;
using System.Data.SqlClient;
namespace HW_15_04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            if(scon.State == ConnectionState.Open)
                System.Console.WriteLine("Connected successfully");
            else 
                System.Console.WriteLine("Oooops, some problems");*/
            System.Console.WriteLine("Welcom to FriendBook! Here you can note information about your friends");
            System.Console.WriteLine("How many friends do you have?");
            int n = int.Parse(Console.ReadLine());
            SCommands firstEnter = new SCommands();
            for (int i = 0; i < n; i++){
                System.Console.Write($"Please enter Firstname of your {++i} friend: ");
                firstEnter.FirstName = Console.ReadLine();
                System.Console.Write($"Please enter Middlename of your {++i} friend: ");
                firstEnter.MiddleName = Console.ReadLine();
                System.Console.Write($"Please enter Lastname of your {++i} friend: ");
                firstEnter.LastName = Console.ReadLine();
                System.Console.Write($"Please enter date of birth of your {++i} friend(yyyy-mm-dd hh:mm:ss): ");
                firstEnter.BirthDate = Console.ReadLine();
                firstEnter.insertSCommand();
            }
            System.Console.WriteLine("Now you can:\n1. Add new friend\n2. Correct some information about your friends\n3. Delete your friends\n4. Get information about all of your friends\n5. Get information about your friends having specific information");
            int choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1: {
                    System.Console.Write($"Please enter Firstname of your friend: ");
                    firstEnter.FirstName = Console.ReadLine();
                    System.Console.Write($"Please enter Middlename of your friend: ");
                    firstEnter.MiddleName = Console.ReadLine();
                    System.Console.Write($"Please enter Lastname of your friend: ");
                    firstEnter.LastName = Console.ReadLine();
                    System.Console.Write($"Please enter date of birth of your friend(yyyy-mm-dd hh:mm:ss): ");
                    firstEnter.BirthDate = Console.ReadLine();
                    firstEnter.insertSCommand();
                }; break;
                case 2: {
                    start3 :
                    System.Console.WriteLine("What information do you want to correct?\n1. Firstname\n2. Middlename\n3. Lastname\n4. date of birth");
                    choice = int.Parse(Console.ReadLine());
                    switch(choice){
                        case 1: firstEnter.updateFirstName(); break;
                        case 2: firstEnter.updateMiddleName(); break;
                        case 3: firstEnter.updateLastName(); break;
                        case 4: firstEnter.updateBirthDate(); break;
                        default: System.Console.WriteLine("Error! Try again;"); goto start3;
                    }
                    start4 :
                    System.Console.WriteLine("By what information do you want to correct?\n1. id\n2. Firstname\n3. Middlename\n4. Lastname\n5. date of birth");
                    n = int.Parse(Console.ReadLine());
                    switch(n){
                        case 1: firstEnter.choiceKey = "id"; break;
                        case 2: firstEnter.choiceKey = "FirstName"; break;
                        case 3: firstEnter.choiceKey = "MiddleName"; break;
                        case 4: firstEnter.choiceKey = "LastName"; break;
                        case 5: firstEnter.choiceKey = "BirthDate"; break;
                        default: Console.WriteLine("Error! Try again;"); goto start4;
                    }
                    System.Console.WriteLine($"Please set {firstEnter.choiceKey}");
                    firstEnter.key = Console.ReadLine();
                    
                }; break;
                case 3: {
                    start :
                    System.Console.WriteLine("By what information do you want to delete?\n1. id\n2. Firstname\n3. Middlename\n4. Lastname\n5. date of birth");
                    n = int.Parse(Console.ReadLine());
                    switch(n){
                        case 1: firstEnter.choiceKey = "id"; break;
                        case 2: firstEnter.choiceKey = "FirstName"; break;
                        case 3: firstEnter.choiceKey = "MiddleName"; break;
                        case 4: firstEnter.choiceKey = "LastName"; break;
                        case 5: firstEnter.choiceKey = "BirthDate"; break;
                        default: System.Console.WriteLine("Error! Try again;"); goto start;
                    }
                    System.Console.WriteLine($"Please set {firstEnter.choiceKey}");
                    firstEnter.key = Console.ReadLine();
                    firstEnter.Delete();
                    }; break;
                    case 4: firstEnter.selectAllSCommand();break;
                    case 5:{
                        start1 :
                        System.Console.WriteLine("By what information do you want to get information?\n1. id\n2. Firstname\n3. Middlename\n4. Lastname\n5. date of birth");
                        n = int.Parse(Console.ReadLine());
                        switch(n){
                            case 1: firstEnter.choiceKey = "id"; break;
                            case 2: firstEnter.choiceKey = "FirstName"; break;
                            case 3: firstEnter.choiceKey = "MiddleName"; break;
                            case 4: firstEnter.choiceKey = "LastName"; break;
                            case 5: firstEnter.choiceKey = "BirthDate"; break;
                            default: System.Console.WriteLine("Error! Try again;"); goto start1;
                        }
                        System.Console.WriteLine($"Please set {firstEnter.choiceKey}");
                        firstEnter.key = Console.ReadLine();
                        firstEnter.selectByIdSCommand();
                    }; break;
                }
            }
            
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
