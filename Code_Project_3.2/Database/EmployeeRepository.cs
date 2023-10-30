using Code_Project_3._2.Models.Abstract_Models;
using Code_Project_3._2.Models.Domain_Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Code_Project_3._2.Database
{
    public class EmployeeRepository : Repository<Employee>, IDisposable
    {
        private const string CONNECTION_STRING = "Server=127.0.0.1;Port=5432;Database=Employees;User Id=postgres;Password=qwer760H;";
        private readonly NpgsqlConnection _connection;
        private List<Employee> _getElements()
        {
            var results = new List<Employee>();

            string selectQuery = "select * from employees";
            var command = new NpgsqlCommand(selectQuery, _connection);
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt32(dataReader["id"]),
                    Code = dataReader["code"].ToString(),
                    Name = dataReader["name"].ToString(),
                    Surname = dataReader["surname"].ToString(),
                    Fathername = dataReader["fathername"].ToString(),
                    PinCode = dataReader["pincode"].ToString(),
                    Email = dataReader["email"].ToString(),
                    ImageUrl = dataReader["imageurl"].ToString(),
                    DepartmentId = Convert.ToInt32(dataReader["departmentid"])
                };

                results.Add(employee);
            }

            return results;
        }

        public EmployeeRepository()
        {
            _connection = new NpgsqlConnection(CONNECTION_STRING);
            _connection.Open();
        }

        ~EmployeeRepository()
        {
            _connection.Close();
        }

        public override void DeleteElement(string employeeCode)
        {
            var deleteQuery = $"update employees set isdeleted='true' where code='{employeeCode}'";
            var command = new NpgsqlCommand(deleteQuery, _connection);
            command.ExecuteNonQuery();
        }

        public override List<Employee> GetElements(Predicate<Employee> criteria)
        {
            var employees = _getElements();
            return (from e in employees
                   where criteria(e)
                   select e).ToList();
        }

        public override void InsertElement(Employee employee)
        {
            string insertQuery =
            "insert into employees" + "\n" +
            "(code, name, surname, fathername, pincode, email, imageurl, departmentid, isdeleted)" + "\n" +
            "values" + "\n" +
            $"('{employee.Code}', '{employee.Name}', '{employee.Surname}', '{employee.Fathername}', '{employee.PinCode}', '{employee.Email}', '{employee.ImageUrl}', '{employee.DepartmentId}', '{employee.IsDeleted}')";

            var command = new NpgsqlCommand(insertQuery, _connection);
            command.ExecuteNonQuery();
        }

        public override void UpdateElement(int elementId, Employee newElementInstance)
        {
            var updateQuery =
                "update employees set" + " " +
                $"code='{newElementInstance.Code}'" + ", " +
                $"name='{newElementInstance.Name}'" + ", " +
                $"surname='{newElementInstance.Surname}'" + ", " +
                $"fathername='{newElementInstance.Fathername}'" + ", " +
                $"pincode='{newElementInstance.PinCode}'" + ", " +
                $"email='{newElementInstance.Email}'" + ", " +
                $"imageurl='{newElementInstance.ImageUrl}'" + ", " +
                $"departmentid={newElementInstance.DepartmentId}" + " " +
                $"where id={elementId}";

            var command = new NpgsqlCommand(updateQuery, _connection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
