using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.TeamsDAO;

namespace DAO.TeamDAO
{
    public class TeamsDAO
    {
        private ITeams teams;

        private readonly EmpManagementContext _empManagementContext = null;

        private static TeamsDAO instance = null;

        public static TeamsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new TeamsDAO();
                }
                return instance;
            }
        }

        public TeamsDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        public List<Teams> GetTeams()
        {
            return _empManagementContext.Teams.ToList();
        }

        // Get team by manager ID
        public TeamDTO GetTeamByManagerID(int managerID)
        {
            // Read data from sql server
            var team = _empManagementContext.Teams
                .Include(t => t.Manager)
                .ThenInclude(e => e.Role)
                .Include(t => t.Employees)
                .ThenInclude(e => e.Department)
                .FirstOrDefault(t => t.ManagerId == managerID);


            if (team != null)
            {
                TeamDTO teamDTO = new TeamDTO();
                teamDTO.TeamID = team.Id;
                teamDTO.TeamName = team?.TeamName;
                teamDTO.ManagerID = team.ManagerId;
                teamDTO.ManagerName = team.Manager.FirstName + " " + team.Manager.LastName;
                teamDTO.TeamMembers = team.Employees.Select(e => new EmployeeDTO
                {
                    EmployeeID = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    RoleName = e.Role?.RoleName,
                    DepartmentName = e.Department?.DepartmentName
                }).ToList();

                return teamDTO;
            }

            return null;
        }

        /*        public void UpdateTeamName(int teamID, string newTeamName)
                {
                    // Get the team from the database
                    var team = _empManagementContext.Teams.FirstOrDefault(t => t.Id == teamID);

                    if (team != null)
                    {
                        // Update the team name
                        team.TeamName = newTeamName;

                        // Save the changes to the database
                        _empManagementContext.SaveChanges();
                    }
                    else
                    {
                        // Handle the case where the team does not exist
                        throw new ArgumentException("Team not found with the provided ID.");
                    }
                }*/

        public void UpdateTeam(Teams updatedTeam)
        {
            var team = _empManagementContext.Teams
                .FirstOrDefault(t => t.Id == updatedTeam.Id);
            if (team == null)
            {
                return;
            }
            else
            {
                team.TeamName = updatedTeam.TeamName;
                team.ManagerId = updatedTeam.ManagerId;
                _empManagementContext.SaveChanges();
            }
        }



        // Get teamID by managerID
        public int GetTeamIDByManagerID(int managerID)
        {
            var team = _empManagementContext.Teams.FirstOrDefault(t => t.ManagerId == managerID);
            if (team != null)
            {
                return team.Id;
            }
            return -1;
        }

        public Teams GetTeamById(int id)
        {
            // Get the team with the given ID
            var team = _empManagementContext.Teams.FirstOrDefault(t => t.Id == id);

            return team;
        }

        // Clear team session
        public void ClearTeamSession()
        {
            teams = null;
        }

    }
}
