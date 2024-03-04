using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.EmployeeService;
using Service.DepartmentService;
using Service.RoleService;
using Service.TeamsService;

namespace RazorPageEmpManagement.Pages.EmployeeAdminPage
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        private readonly IDepartmentService _departmentService;

        private readonly IRoleService _roleService;

        private readonly ITeamsService _teamsService;

        public EditModel(IEmployeeService employeeService, 
            IDepartmentService departmentService, 
            IRoleService roleService,
            ITeamsService teamsService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _roleService = roleService;
            _teamsService = teamsService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeService.GetEmployeeAccount(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            Employee = employee;

            // You'll need to replace these lines with appropriate service calls
            // ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            // ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            // ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
            ViewData["DepartmentId"] = new SelectList(_departmentService.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewData["RoleId"] = new SelectList(_roleService.GetRoles(), "RoleId", "RoleName");
            ViewData["TeamId"] = new SelectList(_teamsService.GetTeams(), "Id", "TeamName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _employeeService.UpdateEmployee(Employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            // Get id and if return any employee then false
            var employee = _employeeService.GetEmployeeAccount(id);
            if (employee == null)
            {
                return false;
            }
            return true;
        }
    }

}
