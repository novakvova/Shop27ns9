using DAL.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IEFContext _context;
        public RoleRepository(IEFContext context)
        {
            _context = context;
        }
        public Role Add(Role role)
        {
            _context.Set<Role>().Add(role);
            return role;
        }

        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }

        public IQueryable<Role> GetAllRoles()
        {
            return this._context.Set<Role>();
        }

        public Role GetRoleById(int id)
        {
            return this.GetAllRoles()
                .SingleOrDefault(c => c.Id == id);
        }

        public void SaveChange()
        {
            this._context.SaveChanges();
        }
    }
}
