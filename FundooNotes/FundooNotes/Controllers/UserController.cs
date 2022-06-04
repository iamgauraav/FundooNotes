using BussinessLayer.Interface;
using DataBaseLayer.Users;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        FundooContext fundoContext;
        IUserBL userBL;

        public UserController(FundooContext fundoContext, IUserBL userBL)
        {
            this.fundoContext = fundoContext;
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult AddUser(UserPostModel user)
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new { success = true, message = "Registration Sucessfull" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Login/{Email}/{Password}")]
        public ActionResult LoginUser(string Email, string Password)
        {
            try
            {
                var user = fundoContext.User.FirstOrDefault(u=>u.Email == Email);
                if (user == null)
                {
                    return this.BadRequest(new { success = false, message = "Email does not Exists " });
                }
                string token = this.userBL.LoginUser(Email, Password);
                return this.Ok(new { success = true, message = "Login Sucessfull", token = token });
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        [HttpPost("ForgetPassword/{Email}")]
        public ActionResult ForgetPassword(string Email)
        {
            try
            {
                var user = fundoContext.User.FirstOrDefault(u => u.Email == Email);
                if (user == null)
                {
                    return this.BadRequest(new { success = false, message = "Email does not Exist" });
                }
                bool result = this.userBL.ForgetPassword(Email);
                return this.Ok(new { success = true, message = "Email has sent" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
