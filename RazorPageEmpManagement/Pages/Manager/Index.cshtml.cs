using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.TeamsService;
using Service.EmployeeService;
using BusinessObject;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http; // Required for session

namespace RazorPageEmpManagement.Pages.Manager
{
    public class IndexModel : PageModel
    {
        private readonly ITeamsService _teamsService;
        private readonly IEmployeeService _employeeService;

        public Teams Team { get; set; }
        public IList<Employee> Employees { get; set; } = default!;
        public Employee Employee { get; set; }

        public IndexModel(ITeamsService teamsService, IEmployeeService employeeService)
        {
            _teamsService = teamsService;
            _employeeService = employeeService;
        }

        public IActionResult OnGet()
        {
            // Retrieve the managerId from Session
            var managerId = HttpContext.Session.GetInt32("EmployeeId");
            if (!managerId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            if (managerId.HasValue)
            {
                Employees = _employeeService.GetTeamMembersByManagerId(managerId.Value);
            }
            else
            {
                // Handle the case where managerId is not available
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _teamsService.UpdateTeam(Team);

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect the user to the login page
            return RedirectToPage("/Index");
        }

    }
}
