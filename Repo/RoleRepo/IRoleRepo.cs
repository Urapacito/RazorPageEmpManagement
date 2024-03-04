using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;

namespace Repo.RoleRepo
{
    public interface IRoleRepo
    {
        public List<Role> GetRoles();

        public bool UpdateRole(RoleDTO updatedRole);

        public bool AddRole(RoleDTO newRole);

        public bool DeleteRole(int roleId);
    }
}
