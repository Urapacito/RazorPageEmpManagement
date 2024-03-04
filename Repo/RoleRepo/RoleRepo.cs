using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.RoleDAO;
using Repo.RoleRepo;

namespace Repo.RoleRepo
{
    public class RoleRepo : IRoleRepo
    {
        private RoleDAO roleDAO = null;

        public RoleRepo()
        {
            roleDAO = new RoleDAO();
        }

        public List<Role> GetRoles() => roleDAO.GetRoles();

        public bool UpdateRole(RoleDTO updatedRole) => roleDAO.UpdateRole(updatedRole);

        public bool AddRole(RoleDTO newRole) => roleDAO.AddRole(newRole);

        public bool DeleteRole(int roleId) => roleDAO.DeleteRole(roleId);
    }
}
