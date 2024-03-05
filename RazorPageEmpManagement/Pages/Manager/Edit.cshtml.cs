using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.TeamsService;
using BusinessObject;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPageEmpManagement.Pages.Manager
{
    public class EditModel : PageModel
    {
        private readonly ITeamsService _teamsService;

        [BindProperty]
        public Teams Team { get; set; } = default!;
        public Employee Employee { get; set; } = default!;

        public EditModel(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var managerId = HttpContext.Session.GetInt32("EmployeeId");
            if (!managerId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            var teamId = _teamsService.GetTeamIDByManagerID(managerId.Value); // Get the team ID by the manager ID
            var team = _teamsService.GetTeamById(teamId); // Get the Teams object by its ID
            if (team == null)
            {
                return NotFound();
            }
            Team = team;

            ViewData["TeamId"] = new SelectList(_teamsService.GetTeams(), "Id", "TeamName");

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            /*            if (!ModelState.IsValid)
                        {
                            return Page();
                        }*/
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        // Log the error.ErrorMessage here
                        error.ErrorMessage.ToString();
                    }
                }
            }


            var managerId = HttpContext.Session.GetInt32("EmployeeId");
            var teamId = _teamsService.GetTeamIDByManagerID(managerId.Value); // Get the team ID by the manager ID

            if (Team.Id != teamId)
            {
                // The team being edited does not belong to the manager
                ModelState.AddModelError(string.Empty, "You do not have permission to edit this team.");
                return Page();
            }

            try
            {
                // Fetch the current team from the database
                var currentTeam = _teamsService.GetTeamById(Team.Id);

                // Update the team name
                currentTeam.TeamName = Team.TeamName;

                // Save the updated team
                _teamsService.UpdateTeam(currentTeam);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle exception here
            }

            return RedirectToPage("./Index");
        }


    }
}
