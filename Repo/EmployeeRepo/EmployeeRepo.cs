using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.EmployeeDAO;

namespace Repo.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private EmployeeDAO employeeDAO = null;

        public EmployeeRepo()
        {
            employeeDAO = new EmployeeDAO();
        }

        /*        public List<EmployeeDTO> GetAllEmployees() => employeeDAO.GetAllEmployees();*/

        public Employee GetEmployeeAccount(int accountID) => employeeDAO.GetEmployeeAccount(accountID);

        public List<Employee> GetEmployees() => employeeDAO.GetEmployees();

        public void UpdateEmployee(Employee updatedEmployee) => employeeDAO.UpdateEmployee(updatedEmployee);

        public void AddEmployee(Employee newEmployee) => employeeDAO.AddEmployee(newEmployee);

        public void DeleteEmployee(int employeeId) => employeeDAO.DeleteEmployee(employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId) => employeeDAO.GetUserInfoById(employeeId);

        public int GetEmployeeID(string username, string password) => employeeDAO.GetEmployeeID(username, password);


        public void ClearEmployeeSession() => employeeDAO.ClearEmployeeSession();



        public List<Employee> GetTeamMembersByManagerId(int managerId) => employeeDAO.GetTeamMembersByManagerId(managerId);
    }
}
