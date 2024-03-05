﻿using System;
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

        public Department GetDepartmentById(int departmentId);

        public List<Department> GetDepartment();

        public void UpdateDepartment(Department updatedDepartment);

        public void AddDepartment(Department newDepartment);

        public void DeleteDepartment(int departmentId);
    }
}
