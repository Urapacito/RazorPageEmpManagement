using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.DepartmentDAO;
using Repo.DepartmentRepo;

namespace Service.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private DepartmentRepo departmentRepo = null;

        public DepartmentService()
        {
            departmentRepo = new DepartmentRepo();
        }

        public Department GetDepartmentById(int departmentId) => departmentRepo.GetDepartmentById(departmentId);

        public List<Department> GetDepartment() => departmentRepo.GetDepartment();

        public void UpdateDepartment(Department updatedDepartment) => departmentRepo.UpdateDepartment(updatedDepartment);

        public void AddDepartment(Department newDepartment) => departmentRepo.AddDepartment(newDepartment);

        public void DeleteDepartment(int departmentId) => departmentRepo.DeleteDepartment(departmentId);
    }
}
