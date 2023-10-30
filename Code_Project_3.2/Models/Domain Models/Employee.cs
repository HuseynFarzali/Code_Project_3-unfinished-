using Code_Project_3._2.Models.Abstract_Models;
using System;
using System.Runtime.CompilerServices;

namespace Code_Project_3._2.Models.Domain_Models
{
    public class Employee : IRepositoryElement
    {
        private const int EMPLOYEE_CODE_LENGTH = 6;
        public string GenerateEmployeeCode()
        {
            var randomGenerator = new Random();
            int randomCode = randomGenerator.Next((int)Math.Pow(10, EMPLOYEE_CODE_LENGTH - 1));

            return "E" + randomCode.ToString().PadLeft(EMPLOYEE_CODE_LENGTH - 1, '0');
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string IsDeleted { get; set; }

        public Employee(int id, string code, string name, string surname, string fathername, string pinCode, string email, string imageUrl, int departmentId, Department department, string isDeleted)
        {
            Id = id;
            Code = code;
            Name = name;
            Surname = surname;
            Fathername = fathername;
            PinCode = pinCode;
            Email = email;
            ImageUrl = imageUrl;
            DepartmentId = departmentId;
            Department = department;
            IsDeleted = isDeleted;
        }

        public Employee() : this(default, default, default, default, default, default, default, default, default, default, "false") { }
    }
}
