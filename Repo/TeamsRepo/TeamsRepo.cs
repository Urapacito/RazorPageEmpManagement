using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.TeamDAO;

namespace Repo.TeamsRepo
{
    public class TeamsRepo : ITeamsRepo
    {
        private TeamsDAO teamsDAO = null;

        public TeamsRepo()
        {
            teamsDAO = new TeamsDAO();
        }

        public List<Teams> GetTeams() => teamsDAO.GetTeams();

        public TeamDTO GetTeamByManagerID(int managerID) => teamsDAO.GetTeamByManagerID(managerID);

        public void UpdateTeam(Teams updatedTeam) => teamsDAO.UpdateTeam(updatedTeam);

        public int GetTeamIDByManagerID(int managerID) => teamsDAO.GetTeamIDByManagerID(managerID);

        public Teams GetTeamById(int id) => teamsDAO.GetTeamById(id);

        public void ClearTeamSession() => teamsDAO.ClearTeamSession();
    }
}
