using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace DAO.EmployeeDAO
{
    public class EmployeeDAO
    {
        private IEmployee employee;

        private readonly EmpManagementContext _empManagementContext = null;

        private static EmployeeDAO instance = null;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new EmployeeDAO();
                }
                return instance;
            }
        }

        public EmployeeDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        public Employee GetEmployeeAccount(int accountID)
        {
            return _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .Include(e => e.Team)
                .FirstOrDefault(e => e.EmployeeId == accountID);
        }

        // Get all employee using Employee.cs
        public List<Employee> GetEmployees()
        {
            return _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .Include(e => e.Team)
                .ToList();
        }


        // Update employee
        public void UpdateEmployee(Employee updatedEmployee)
        {
/*            Employee employee = GetEmployeeAccount(updatedEmployee.EmployeeId);
            if (employee != null)
            {
                _empManagementContext.Remove(employee);
                _empManagementContext.Update(updatedEmployee);
                _empManagementContext.SaveChanges();
            }*/

            // Update employee but also get department and role
            var employee = _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .Include(e => e.Team)
                .FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeId);
            if (employee == null)
            {
                return;
            }
            else
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.RoleId = updatedEmployee.RoleId;
                employee.DepartmentId = updatedEmployee.DepartmentId;
                employee.TeamId = updatedEmployee.TeamId;

                _empManagementContext.Remove(employee);
                _empManagementContext.Update(updatedEmployee);
                _empManagementContext.SaveChanges();
            }
        }


        public void AddEmployee(Employee newEmployee)
        {
            _empManagementContext.Employees.Add(newEmployee);
            _empManagementContext.SaveChanges();
        }


        public void DeleteEmployee(int employeeId)
        {
            var employee = _empManagementContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                _empManagementContext.Employees.Remove(employee);
                _empManagementContext.SaveChanges();
            }
        }

        // Get imployeeID
        public int GetEmployeeID(string username, string password)
        {
            var employee = _empManagementContext.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
            if (employee != null)
            {
                return employee.EmployeeId;
            }
            else
            {
                return -1;
            }
        }

        // Show employee information in employee page
        public EmployeeDTO GetUserInfoById(int employeeId)
        {
            // Find the employee in the database
            var employee = _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            // Check if the employee exists
            if (employee != null)
            {
                // If the employee exists, convert it to an EmployeeDTO and return it
                EmployeeDTO employeeDTO = new EmployeeDTO
                {
                    EmployeeID = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    RoleName = employee.Role.RoleName,
                    DepartmentName = employee.Department.DepartmentName,
                    Username = employee.Username,
                    Password = employee.Password,
                    TeamID = employee.TeamId
                };

                return employeeDTO;
            }
            else
            {
                // If the employee does not exist, return null
                return null;
            }
        }


        // Clear session
        public void ClearEmployeeSession()
        {
            // If the session data is stored in memory, nullify or reset the variables
            employee = null;

            // If the session data is stored in the database, update the database
            // For example, if you have a 'Session' table in your database:
            /*
            var session = _empManagementContext.Sessions.FirstOrDefault(s => s.EmployeeId == employee.EmployeeId);
            if (session != null)
            {
                session.IsActive = false;
                _empManagementContext.SaveChanges();
            }
            */

            // If you're using an authentication library that provides a method to invalidate the session, call that method
            // For example:
            // FormsAuthentication.SignOut();
        }

        public List<Employee> GetTeamMembersByManagerId(int managerId)
        {
            // Get the manager
            var manager = _empManagementContext.Employees
                .Include(e => e.Team)
                .SingleOrDefault(e => e.EmployeeId == managerId);

            if (manager == null)
            {
                // Handle the case where the manager is not found...
                return new List<Employee>();
            }

            // Get the employees who are members of the manager's team
            var teamMembers = _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .Where(e => e.TeamId == manager.TeamId)
                .ToList();

            return teamMembers.ToList();
        }
    }

}
