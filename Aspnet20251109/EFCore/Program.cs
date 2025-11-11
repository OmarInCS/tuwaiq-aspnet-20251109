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



// -------------------- Select ------------------------

//var emps = hrDB.Employees.ToList();


//var emps = hrDB.Employees
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.DepartmentId,
//    })
//    .ToList();


//var emps = hrDB.Employees
//    .Where(e => e.JobId == "IT_PROG")
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.DepartmentId,
//    })
//    .ToList();


//var emps = hrDB.Employees
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.DepartmentId,
//    })
//    .ToList();


//var emps = hrDB.Employees
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.DepartmentId,
//    })
//    .OrderByDescending(e => e.Salary)
//    .ToList();

// Lazy Loading
//var emps = hrDB.Employees
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.Job.JobTitle,
//        e.Job.MinSalary,
//        e.DepartmentId,
//        e.Department.DepartmentName
//    })
//    .ToList();


// Eager Loading
//var emps = hrDB.Employees
//    .Include(e => e.Job)
//    .Include(e => e.Department)
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.Job.JobTitle,
//        e.Job.MinSalary,
//        e.DepartmentId,
//        e.Department.DepartmentName
//    })
//    .ToList();


//var emps = hrDB.Employees
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.Job.JobTitle,
//        e.Job.MinSalary,
//        e.DepartmentId,
//        e.Department.DepartmentName,
//        e.Department.Location.City
//    })
//    .ToList();


//var emps = hrDB.Employees
//    .Include(e => e.Job)
//    .Include(e => e.Department)
//    .ThenInclude(d => d.Location)
//    .Where(e => e.Salary >= 5000 && e.Salary <= 10000)
//    .Select(e => new {
//        e.LastName,
//        e.Salary,
//        e.JobId,
//        e.Job.JobTitle,
//        e.Job.MinSalary,
//        e.DepartmentId,
//        e.Department.DepartmentName,
//        e.Department.Location.City
//    })
//    .ToList();


//var empsITsSalary = hrDB.Employees
//    .Where(e => e.JobId == "IT_PROG")
//    .Select(e => e.Salary)
//    .Sum();


//var deptsTotalSalary = hrDB.Employees
//    .GroupBy(e => e.JobId)
//    .Select(g => new {
//        Job = g.Key,
//        NumOfEmps = g.Count(),
//        TotalOfSalaries = g.Select(e => e.Salary).Sum()
//    })
//    .ToList();

var emps = hrDB.Employees
    //.AsNoTracking()
    .Where(e => e.JobId == "IT_PROG")
    .ToList();

emps[0].Salary = 88888;
hrDB.SaveChanges();

Console.WriteLine();

// Select all employees in department 30

// Select all employees of Seattle city and show their department name 

// Select number of employees hired in each year


