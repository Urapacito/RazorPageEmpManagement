using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo.SimpleSecurityRepo;

namespace Service.SimpleSecurityService
{
    public class SimpleSecurityService : ISimpleSecurityService
    {
        private readonly ISimpleSecurityRepo simpleSecurityRepo = null;

        public SimpleSecurityService()
        {
            simpleSecurityRepo = new SimpleSecurityRepo();
        }

        public (string Role, int EmployeeId) GetUserRole(string username, string password) => simpleSecurityRepo.GetUserRole(username, password);
    }
}
