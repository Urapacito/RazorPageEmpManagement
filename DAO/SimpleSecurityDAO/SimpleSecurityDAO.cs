using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO.EmployeeDAO;

namespace DAO.SimpleSecurityDAO
{
    public class SimpleSecurityDAO
    {

        private ISecurity security;

        private readonly EmpManagementContext _empManagementContext = null;

        private static SimpleSecurityDAO instance = null;

        public static SimpleSecurityDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new SimpleSecurityDAO();
                }
                return instance;
            }
        }

        public SimpleSecurityDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        public (string Role, int EmployeeId) GetUserRole(string username, string password)
        {
            // Get the employee with the given username
            var employee = _empManagementContext.Employees
                .Include(e => e.Role)
                .FirstOrDefault(e => e.Username == username && e.Password == password);

            // Check if the employee exists
            if (employee != null)
            {
                // If the employee exists, return their role name and employee ID
                return (employee.Role.RoleName, employee.EmployeeId);
            }
            else
            {
                // If the employee does not exist, return null or an appropriate message
                return (null, 0);
            }
        }

    }
}
