using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.DepartmentDAO;

namespace Repo.DepartmentRepo
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private DepartmentDAO departmentDAO = null;

        public DepartmentRepo()
        {
            departmentDAO = new DepartmentDAO();
        }

        public Department GetDepartmentById(int departmentId) => departmentDAO.GetDepartmentById(departmentId);

        public List<Department> GetDepartment() => departmentDAO.GetDepartment();

        public void UpdateDepartment(Department updatedDepartment) => departmentDAO.UpdateDepartment(updatedDepartment);

        public void AddDepartment(Department newDepartment) => departmentDAO.AddDepartment(newDepartment);

        public void DeleteDepartment(int departmentId) => departmentDAO.DeleteDepartment(departmentId);
    }
}
