﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.EmployeeDAO;
using Microsoft.EntityFrameworkCore;

namespace DAO.DepartmentDAO
{
    public class DepartmentDAO
    {
        private IDepartment department;

        private readonly EmpManagementContext _empManagementContext = null;

        private static DepartmentDAO instance = null;

        public static DepartmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new DepartmentDAO();
                }
                return instance;
            }
        }

        public DepartmentDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        // Get all departments 
        public List<Department> GetDepartment()
        {
            return _empManagementContext.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _empManagementContext.Departments
                .FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        // Update department
/*        public bool UpdateDepartment(DepartmentDTO updatedDepartment)
        {
            try
            {
                // Find the department in the database
                var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentId == updatedDepartment.DepartmentID);

                if (department != null)
                {
                    // Update the department's details
                    department.DepartmentName = updatedDepartment.DepartmentName;

                    // Save the changes
                    _empManagementContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }*/

        public void UpdateDepartment(Department updatedDepartment)
        {
            var department = _empManagementContext.Departments
                .FirstOrDefault(d => d.DepartmentId == updatedDepartment.DepartmentId);
            if (department == null)
            {
                return;
            }
            else
            {
                department.DepartmentName = updatedDepartment.DepartmentName;
                _empManagementContext.SaveChanges();
            }
        }

        // Add department
/*        public bool AddDepartment(DepartmentDTO newDepartment)
        {
            try
            {
                // Create a new department
                Department department = new Department
                {
                    DepartmentName = newDepartment.DepartmentName
                };

                // Add the new department to the database
                _empManagementContext.Departments.Add(department);
                _empManagementContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }*/

        public void AddDepartment(Department newDepartment)
        {
            _empManagementContext.Departments.Add(newDepartment);
            _empManagementContext.SaveChanges();
        }

        // Delete department
/*        public bool DeleteDepartment(int departmentId)
        {
            try
            {
                // Find the department in the database
                var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);

                if (department != null)
                {
                    // Remove the department from the database
                    _empManagementContext.Departments.Remove(department);
                    _empManagementContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }*/

        public void DeleteDepartment(int departmentId)
        {
            var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                _empManagementContext.Departments.Remove(department);
                _empManagementContext.SaveChanges();
            }
        }
    }
}
