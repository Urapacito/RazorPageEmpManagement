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

        public List<Department> GetDepartment() => departmentDAO.GetDepartment();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment) => departmentDAO.UpdateDepartment(updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment) => departmentDAO.AddDepartment(newDepartment);

        public bool DeleteDepartment(int departmentId) => departmentDAO.DeleteDepartment(departmentId);
    }
}
