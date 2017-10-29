using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstact
{
    public interface IRoleRepository : IDisposable
    {
        Role Add(Role role);
        IQueryable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void SaveChange();
    }
}
