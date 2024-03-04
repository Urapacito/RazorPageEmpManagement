using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SimpleSecurityService
{
    public interface ISimpleSecurityService
    {
        public (string Role, int EmployeeId) GetUserRole(string username, string password);
    }
}
