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
    public interface IDepartmentRepo
    {
        /*        public List<DepartmentDTO> GetAllDepartments();*/

        public List<Department> GetDepartment();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment);

        public bool DeleteDepartment(int departmentId);
    }
}
