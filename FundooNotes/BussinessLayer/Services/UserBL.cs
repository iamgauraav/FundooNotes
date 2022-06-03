using BussinessLayer.Interface;
using DataBaseLayer.Users;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;
        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }

        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                this.userRl.AddUser(userPostModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
