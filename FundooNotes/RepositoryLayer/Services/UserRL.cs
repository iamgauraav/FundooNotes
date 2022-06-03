using DataBaseLayer.Users;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext Fundoocontext;
        IConfiguration configuration;

        public UserRL(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.Fundoocontext = fundoocontext;
            this.configuration = configuration;
        }
        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.FirstName = userPostModel.FirstName;
                user.LastName = userPostModel.LastName;
                user.Email = userPostModel.Email;
                user.Password = userPostModel.Password;
                user.Address = userPostModel.Address;
                user.CreatedDate = DateTime.Now; 
                user.ModifiedDate = DateTime.Now;
                Fundoocontext.Add(user);
                Fundoocontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
