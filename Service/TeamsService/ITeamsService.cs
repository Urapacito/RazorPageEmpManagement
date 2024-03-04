using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace Service.TeamsService
{
    public interface ITeamsService
    {
        public List<Teams> GetTeams();

        public TeamDTO GetTeamByManagerID(int managerID);

        public void UpdateTeam(Teams updatedTeam);

        public int GetTeamIDByManagerID(int managerID);

        public Teams GetTeamById(int id);

        public void ClearTeamSession();
    }
}
