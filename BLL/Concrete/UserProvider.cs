using BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Abstact;
using DAL.Entities;
using System.Web.Security;
using BLL.ViewModels.Admin;
using System.Transactions;
namespace BLL.Concrete
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserProvider(IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public int DeleteUserRole(int userId, int roleId)
        {
            var role = _roleRepository.GetRoleById(roleId);
            if (role != null)
            {
                var user = _userRepository.GetUserById(userId);
                if (user != null)
                {
                    user.Roles.Remove(role);
                    _userRepository.SaveChange();
                    return 1;
                }
            }
            return 0;
        }

        public UserEditViewModel Edit(int id)
        {
            UserEditViewModel model = null;
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                model = new UserEditViewModel();
                model.Id = user.Id;
                model.Email = user.Email;
                model.Roles = user.Roles.Select(r => r.Id).ToArray();
            }
            return model;
        }

        public int Edit(UserEditViewModel editUser)
        {
            var user = _userRepository.GetUserById(editUser.Id);
            if (user != null)
            {
                using (var transaction = new TransactionScope())
                {
                    user.Email = editUser.Email;
                    user.Roles.Clear();
                    _userRepository.SaveChange();
                    foreach (var roleId in editUser.Roles)
                    {
                        var role = _roleRepository.GetRoleById(roleId);
                        if (role != null)
                        {
                            user.Roles.Add(role);
                        }
                    }
                    _userRepository.SaveChange();
                    transaction.Complete();
                }
                return user.Id;
            }
            return 0;
        }

        public IEnumerable<UserItemViewModel> GetAllUsers()
        {
            IEnumerable<UserItemViewModel> users =
                _userRepository.GetAllUsers()
                .Select(u => new UserItemViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Roles = u.Roles.Select(r => new RoleItemViewModel
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                });
            return users;
        }

        public IEnumerable<ItemSelectViewModel> GetListItemRoles()
        {
            return _roleRepository.GetAllRoles()
                .Select(r => new ItemSelectViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                });
        }
    }
}
