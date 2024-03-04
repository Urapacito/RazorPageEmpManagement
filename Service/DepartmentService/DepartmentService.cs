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

        public List<Department> GetDepartment() => departmentRepo.GetDepartment();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment) => departmentRepo.UpdateDepartment(updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment) => departmentRepo.AddDepartment(newDepartment);

        public bool DeleteDepartment(int departmentId) => departmentRepo.DeleteDepartment(departmentId);
    }
}
