using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.EmployeeService;

namespace RazorPageEmpManagement.Pages.EmployeeAdminPage
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService = null;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public IActionResult OnGet()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");

            if (!employeeId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            // Get all employees from
            Employee = _employeeService.GetEmployees();

            return Page();
        }

        // Logout logic
        public IActionResult OnPost()
        {
            _employeeService.ClearEmployeeSession();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDepartment()
        {
            // Redirect to the Departments index page
            return RedirectToPage("/Admin/Departments/Index");
        }

    }
}
