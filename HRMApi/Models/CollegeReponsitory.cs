using System;
namespace HRMApi.Models
{
    public static class CollegeReponsitory
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>() {
        new Employee
        {
            Id = "001",
            Name = "Janh ha",
            Email = "ha@gmail",
            Department = "dev"
        },
        new Employee
        {
            Id = "002",
            Name = "Manh huu",
            Email = "manh@gmail",
            Department = "dev"
        },new Employee
        {
            Id = "003",
            Name = "Jagy ",
            Email = "ha@gmail",
            Department = "dev"
        },new Employee
        {
            Id = "004",
            Name = "Ka jaj",
            Email = "ka@gmail",
            Department = "dev"
        },new Employee
        {
            Id = "005",
            Name = "Ha",
            Email = "h@gmail",
            Department = "man"

         }
         };

    }
}
