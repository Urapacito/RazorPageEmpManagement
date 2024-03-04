using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.SimpleSecurityDAO
{
    public interface ISecurity
    {
        public (string Role, int EmployeeId) GetUserRole(string username, string password);
    }
}
