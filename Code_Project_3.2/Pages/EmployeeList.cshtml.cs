using Code_Project_3._2.Database;
using Code_Project_3._2.Models.Domain_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Code_Project_3._2.Pages
{
    public class EmployeeListModel : PageModel
    {
        public EmployeeRepository employeeRepository = new();
        public List<Employee> AvailableEmployees { get; set; }
        public void OnGet()
        {
            AvailableEmployees = employeeRepository.GetElements(emp => emp.IsDeleted == "false");
        }
    }
}
