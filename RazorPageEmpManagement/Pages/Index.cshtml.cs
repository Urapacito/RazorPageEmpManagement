using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.SimpleSecurityService;
using Microsoft.AspNetCore.Http; // Required for session

namespace RazorPageEmpManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISimpleSecurityService _securityService;

        [BindProperty]
        public string Username { get; set; } // Changed from Email to Username

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ISimpleSecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var (role, employeeId) = _securityService.GetUserRole(Username, Password);

            if (role == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Store the employeeId in Session
            HttpContext.Session.SetInt32("EmployeeId", employeeId);

            // Redirect the user to the appropriate page based on their role
            switch (role)
            {
                case "Admin":
                    return RedirectToPage("/Admin/Employee/Index");
                case "Manager":
                    return RedirectToPage("/Manager/Index");
                case "Employee":
                    return RedirectToPage("/EmployeePage/Details");
                default:
                    ModelState.AddModelError(string.Empty, "You do not have the necessary permissions to access this page.");
                    return Page();
            }
        }
    }
}
