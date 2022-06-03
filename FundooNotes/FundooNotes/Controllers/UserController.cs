using BussinessLayer.Interface;
using DataBaseLayer.Users;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;

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
    }
}
