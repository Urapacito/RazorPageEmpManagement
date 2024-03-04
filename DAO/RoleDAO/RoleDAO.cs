﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.EmployeeDAO;

namespace DAO.RoleDAO
{
    public class RoleDAO
    {
        private IRole role;

        private readonly EmpManagementContext _empManagementContext = null;

        private static RoleDAO instance = null;

        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new RoleDAO();
                }
                return instance;
            }
        }

        public RoleDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        // Get all roles
        public List<Role> GetRoles()
        {
            return _empManagementContext.Roles.ToList();
        }

        // Update role
        public bool UpdateRole(RoleDTO updatedRole)
        {
            try
            {
                // Find the role in the database
                var role = _empManagementContext.Roles.FirstOrDefault(r => r.RoleId == updatedRole.RoleID);

                if (role != null)
                {
                    // Update the role's details
                    role.RoleName = updatedRole.RoleName;

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
        }

        // Add role
        public bool AddRole(RoleDTO newRole)
        {
            try
            {
                Role role = new Role();
                role.RoleName = newRole.RoleName;

                _empManagementContext.Roles.Add(role);
                _empManagementContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete role
        public bool DeleteRole(int roleId)
        {
            try
            {
                var role = _empManagementContext.Roles.FirstOrDefault(r => r.RoleId == roleId);
                if (role != null)
                {
                    _empManagementContext.Roles.Remove(role);
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
        }
    }
}
