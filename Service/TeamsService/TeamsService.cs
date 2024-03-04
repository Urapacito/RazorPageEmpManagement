using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.SimpleSecurityDAO;
using Repo.TeamsRepo;

namespace Service.TeamsService
{
    public class TeamsService : ITeamsService
    {
        private TeamsRepo teamsRepo = null;

        public TeamsService()
        {
            teamsRepo = new TeamsRepo();
        }

        public List<Teams> GetTeams() => teamsRepo.GetTeams();

        public TeamDTO GetTeamByManagerID(int managerID) => teamsRepo.GetTeamByManagerID(managerID);

        public void UpdateTeam(Teams updatedTeam) => teamsRepo.UpdateTeam(updatedTeam);

        public int GetTeamIDByManagerID(int managerID) => teamsRepo.GetTeamIDByManagerID(managerID);

        public Teams GetTeamById(int id) => teamsRepo.GetTeamById(id);

        public void ClearTeamSession() => teamsRepo.ClearTeamSession();
    }
}
