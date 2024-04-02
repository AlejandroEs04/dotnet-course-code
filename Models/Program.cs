using System;
using System.Data;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Dapper;
using Microsoft.Data.SqlClient;
using ModelsCourse.Models;

namespace ModelsCourse 
{
    internal class Program 
    {
        static void Main(string[] agrs) 
        {
            string connectionString = "Server=DESKTOP-V7L03UB\MSSQLSERVER02;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow);

            // Computer myComputer = new Computer()
            // {
            //     Motherboard = "Z690", 
            //     hasWifi = true, 
            //     HasLTE = false, 
            //     ReleaseDate = DateTime.Now, 
            //     Price = 946.80m, 
            //     CPUCores = 8, 
            //     VideoCard = "RTX 2060"
            // };

            // myComputer.hasWifi = false;

            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.Price);
            // Console.WriteLine(myComputer.CPUCores);
            // Console.WriteLine(myComputer.HasLTE);
            // Console.WriteLine(myComputer.hasWifi);
            // Console.WriteLine(myComputer.VideoCard);
            // Console.WriteLine(myComputer.ReleaseDate);
        }
    }
}