using Code_Project_3._2.Database;
using Code_Project_3._2.Models.Domain_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace Code_Project_3._2.Pages
{
    public class EmployeeAddModel : PageModel
    {
        public EmployeeRepository employeeRepository = new();


        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Surname { get; set; }

        [BindProperty]
        public string Fathername { get; set; }

        [BindProperty]
        public string PinCode { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string ImageUrl { get; set; }

        [BindProperty]
        public int DepartmentId { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            employeeRepository.InsertElement(new Employee()
            {
                Code = new Employee().GenerateEmployeeCode(),
                Name = Name,
                Surname = Surname,
                Fathername = Fathername,
                PinCode = PinCode,
                Email = Email,
                ImageUrl = ImageUrl,
                DepartmentId = DepartmentId
            });

            return RedirectToPage("~/admin/employeelist");
        }
    }
}
