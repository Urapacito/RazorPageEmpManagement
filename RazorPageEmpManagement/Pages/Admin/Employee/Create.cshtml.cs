using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service.EmployeeService;
using Service.RoleService;
using Service.DepartmentService;
using Service.TeamsService;

namespace RazorPageEmpManagement.Pages.EmployeeAdminPage
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        private readonly IRoleService _roleService;

        private readonly IDepartmentService _departmentService;

        private readonly ITeamsService _teamService;

        public CreateModel(IEmployeeService employeeService, 
            IRoleService roleService,
            IDepartmentService departmentService,
            ITeamsService teamService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _departmentService = departmentService;
            _teamService = teamService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public IActionResult OnGet()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (!employeeId.HasValue)
            {
                return RedirectToPage("/Index");
            }
            // You'll need to replace these lines with appropriate service calls
            // ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            // ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            // ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
            ViewData["DepartmentId"] = new SelectList(_departmentService.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewData["RoleId"] = new SelectList(_roleService.GetRoles(), "RoleId", "RoleName");
            ViewData["TeamId"] = new SelectList(_teamService.GetTeams(), "Id", "TeamName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeService.AddEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }

}
