using DataBaseLayer.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IUserBL
    {
        public void AddUser(UserPostModel userPostModel);

        public string LoginUser(string Email, string Password);

        public bool ForgetPassword(string Emails);
    }
}
