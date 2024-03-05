using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service.DepartmentService;

namespace RazorPageEmpManagement.Pages.Admin.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentService _departmentService = null;

        public CreateModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult OnGet()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (!employeeId.HasValue)
            {
                return RedirectToPage("/Index");
            }



            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _departmentService.AddDepartment(Department);

            return RedirectToPage("./Index");
        }
    }
}
