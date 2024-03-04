using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace Service.EmployeeService
{
    public interface IEmployeeService
    {
        /*        public List<EmployeeDTO> GetAllEmployees();*/

        public Employee GetEmployeeAccount(int accountID);

        public List<Employee> GetEmployees();

        public void UpdateEmployee(Employee updatedEmployee);

        public void AddEmployee(Employee newEmployee);

        public void DeleteEmployee(int employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId);

        public int GetEmployeeID(string username, string password);


        public void ClearEmployeeSession();


        public List<Employee> GetTeamMembersByManagerId(int managerId);
    }
}
