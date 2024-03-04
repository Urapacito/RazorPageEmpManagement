using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.EmployeeDAO;
using Repo.EmployeeRepo;

namespace Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo = null;

        public EmployeeService()
        {
            employeeRepo = new EmployeeRepo();
        }

        /*        public List<EmployeeDTO> GetAllEmployees() => employeeRepo.GetAllEmployees();*/

        public Employee GetEmployeeAccount(int accountID) => employeeRepo.GetEmployeeAccount(accountID);

        public List<Employee> GetEmployees() => employeeRepo.GetEmployees();

        public void UpdateEmployee(Employee updatedEmployee) => employeeRepo.UpdateEmployee(updatedEmployee);

        public void AddEmployee(Employee newEmployee) => employeeRepo.AddEmployee(newEmployee);

        public void DeleteEmployee(int employeeId) => employeeRepo.DeleteEmployee(employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId) => employeeRepo.GetUserInfoById(employeeId);

        public int GetEmployeeID(string username, string password) => employeeRepo.GetEmployeeID(username, password);


        public void ClearEmployeeSession() => employeeRepo.ClearEmployeeSession();



        public List<Employee> GetTeamMembersByManagerId(int managerId) => employeeRepo.GetTeamMembersByManagerId(managerId);
    }
}
