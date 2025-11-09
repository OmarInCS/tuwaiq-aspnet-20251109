// See https://aka.ms/new-console-template for more information
using EFCore.HrModels;

Console.WriteLine("Hello, World!");

var hrDB = new HrContext();

var numOfDepartments = hrDB.Departments.Count();

Console.WriteLine($"# Departments: {numOfDepartments}");

//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Tools
