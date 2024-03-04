using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using DAO.RoleDAO;
using Repo.RoleRepo;

namespace Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo roleRepo = null;

        public RoleService()
        {
            roleRepo = new RoleRepo();
        }

        public List<Role> GetRoles() => roleRepo.GetRoles();

        public bool UpdateRole(RoleDTO updatedRole) => roleRepo.UpdateRole(updatedRole);

        public bool AddRole(RoleDTO newRole) => roleRepo.AddRole(newRole);

        public bool DeleteRole(int roleId) => roleRepo.DeleteRole(roleId);

    }
}
