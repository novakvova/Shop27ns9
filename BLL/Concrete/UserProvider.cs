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
namespace BLL.Concrete
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;


        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserItemViewModel> GetAllUsers()
        {
            IEnumerable<UserItemViewModel> users=
                _userRepository.GetAllUsers()
                .Select(u=> new UserItemViewModel {
                    Id=u.Id,
                    Email=u.Email,
                    Roles=u.Roles.Select(r=>new RoleItemViewModel {
                        Id=r.Id,
                        Name=r.Name
                    })
                });
            return users;
        }

       
    }
}
