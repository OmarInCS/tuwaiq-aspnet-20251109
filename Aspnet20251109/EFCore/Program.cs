// See https://aka.ms/new-console-template for more information
using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var hrDB = new HrContext();

var numOfDepartments = hrDB.Departments.Count();

Console.WriteLine($"# Departments: {numOfDepartments}");

//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Tools

// LINQ + CRUD

var clinicDB = new ClinicContext();

// --------------- Create -----------------
//var p1 = new Patient {
//    FullName = "Wael",
//    Email = "w@gmail.com",
//    NationalId = "1234567890",
//    PhoneNumber = "1234567890"
//};

//clinicDB.Patients.Add(p1);
//clinicDB.SaveChanges();

//var p2 = new Patient {
//    FullName = "Saad",
//    Email = "s@gmail.com",
//    NationalId = "1234567890",
//    PhoneNumber = "1234567890",
//    DateOfBirth = new DateOnly(2020, 10, 10)
//};

//clinicDB.Patients.Add(p2);
//clinicDB.SaveChanges();

// ------------- Update ------------------
//var p1 = clinicDB.Patients.Find(1);
//p1.DateOfBirth = new DateOnly(2000, 01, 01);
//clinicDB.SaveChanges();


//var p2 = clinicDB.Patients.FirstOrDefault(p => p.FullName == "Saad");
//if (p2 != null) {
//    p2.FullName = "Saad Saad";
//    clinicDB.SaveChanges();
//}


//var patients = clinicDB.Patients.Where(p => p.DateOfBirth >= new DateOnly(2000, 01, 01)).ToList();
//foreach (var p in patients)
//{
//    p.DateOfBirth = new DateOnly(2010, 5, 5);
//}

//clinicDB.SaveChanges();


//clinicDB.Patients
//.Where(p => p.FullName == "Saad Saad")
//.ExecuteUpdate(p => p.SetProperty(p => p.Email, "ssssss@gmail.com"));


// ------------- Delete ---------------------
//var p1 = clinicDB.Patients.Find(2);
//clinicDB.Patients.Remove(p1);
//clinicDB.SaveChanges();


