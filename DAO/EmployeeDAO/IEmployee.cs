using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace DAO.EmployeeDAO
{
    public interface IEmployee
    {
        // ADMIN PAGE METHODS 
        /*        public List<EmployeeDTO> GetAllEmployees();*/

        public Employee GetEmployeeAccount(int accountID);

        public List<Employee> GetEmployees();

        public void UpdateEmployee(Employee updatedEmployee);

        public void AddEmployee(Employee newEmployee);

        public void DeleteEmployee(int employeeId);

        //EMPLOYEE PAGE METHOD
        public int GetEmployeeID(string username, string password);

        public EmployeeDTO GetUserInfoById(int employeeId);




        // Clear session
        public void ClearSession();


        // FOR MANAGER
        public List<Employee> GetTeamMembersByManagerId(int managerId);
    }
}
