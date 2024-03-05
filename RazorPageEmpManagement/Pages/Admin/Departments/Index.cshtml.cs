using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.DepartmentService;

namespace RazorPageEmpManagement.Pages.Admin.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentService _departmentService = null;

        public IndexModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IList<Department> Department { get;set; } = default!;

        public IActionResult OnGet()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");

            if (!employeeId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            // Get departments from the database
            Department = _departmentService.GetDepartment();

            return Page();
        }
    }
}
