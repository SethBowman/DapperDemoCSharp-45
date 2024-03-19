using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperDemoCSharp_45;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DepartmentRepo(conn);

var departments = departmentRepo.GetAllDepartments();

departmentRepo.InsertDepartment("Cooler Stuff");

foreach (var department in departments)
{
    Console.WriteLine(department.Name);
}