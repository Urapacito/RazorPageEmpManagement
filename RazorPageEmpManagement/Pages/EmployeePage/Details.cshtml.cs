using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.EmployeeService;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.DepartmentService;
using Service.RoleService;
using Service.TeamsService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace RazorPageEmpManagement.Pages.EmployeePage
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IRoleService _roleService;
        private readonly ITeamsService _teamsService;

        [BindProperty]
        public Employee Employee { get; set; }

        public SelectList Departments { get; set; }
        public SelectList Roles { get; set; }
        public SelectList Teams { get; set; }

        public DetailsModel(IEmployeeService employeeService,
            IDepartmentService departmentService,
            IRoleService roleService,
            ITeamsService teamsService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _roleService = roleService;
            _teamsService = teamsService;
        }

        public void OnGet()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            Employee = _employeeService.GetEmployeeAccount(employeeId.Value);
            if (Employee == null)
            {
                RedirectToPage("/Index");
            }

            // Populate the properties with the lists of departments, roles, and teams
            Departments = new SelectList(_departmentService.GetDepartment(), "DepartmentId", "DepartmentName");
            Roles = new SelectList(_roleService.GetRoles(), "RoleId", "RoleName");
            Teams = new SelectList(_teamsService.GetTeams(), "Id", "TeamName");
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
                TempData["SuccessMessage"] = "Employee updated successfully!";
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

            return RedirectToPage("./Details");
        }

        private bool EmployeeExists(int id)
        {
            var employee = _employeeService.GetEmployeeAccount(id);
            if (employee == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }

}
