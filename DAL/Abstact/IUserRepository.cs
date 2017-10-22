﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstact
{
    public interface IUserRepository : IDisposable
    {
        User Add(User user);
        IQueryable<User> GetAllUsers();
        User GetUserByEmail(string email);
        User GetUserById(int id);
        void SaveChange();
    }
}
