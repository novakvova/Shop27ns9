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

namespace BLL.Concrete
{
    public class AccountProvider : IAccountProvider
    {
        private readonly IUserRepository _userRepository;


        public AccountProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public StatusAccountViewModel Login(LoginViewModel model)
        {
            var user = _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var password = crypto.Compute(model.Password, user.PasswordSalt);
                if (password == user.Password)
                {
                    FormsAuthentication
                                .SetAuthCookie(model.Email, model.IsRememberMe);
                    return StatusAccountViewModel.Success;
                }
            }
            return StatusAccountViewModel.Error;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public StatusAccountViewModel Register(RegisterViewModel model)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(model.Email);
                if (user != null)
                    return StatusAccountViewModel.Dublication;
                var crypto = new SimpleCrypto.PBKDF2();
                User newUser = new User();
                newUser.Email = model.Email;
                newUser.Password = crypto.Compute(model.Password);
                newUser.PasswordSalt = crypto.Salt;
                _userRepository.Add(newUser);
                _userRepository.SaveChange();
            }
            catch
            {
                return StatusAccountViewModel.Error;
            }
            return StatusAccountViewModel.Success;
        }

        public IEnumerable<string> UserRoles(string email)
        {
            var user=_userRepository.GetUserByEmail(email);
            return user.Roles.Select(r => r.Name);
        }
    }
}
