using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace Service.DepartmentService
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartment();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment);

        public bool DeleteDepartment(int departmentId);
    }
}
