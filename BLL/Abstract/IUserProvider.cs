using BLL.ViewModels;
using BLL.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IUserProvider
    {
        IEnumerable<UserItemViewModel> GetAllUsers();
        int DeleteUserRole(int userId, int roleId);
        IEnumerable<ItemSelectViewModel> GetListItemRoles();
        UserEditViewModel Edit(int id);
        int Edit(UserEditViewModel editUser);
    }
}
