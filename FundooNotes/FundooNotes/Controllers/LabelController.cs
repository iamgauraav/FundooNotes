using BussinessLayer.Interface;
using DataBaseLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        FundooContext fundooContext;
        ILabelBL labelBL;

        public LabelController(FundooContext fundooContext, ILabelBL labelBL)
        {
            this.fundooContext = fundooContext;
            this.labelBL = labelBL;
        }
        [Authorize]
        [HttpPost("CreateLabel")]

        public async Task<ActionResult> AddLabel(int NoteId, string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.labelBL.CreateLabel(userId, NoteId, LabelName);
                return this.Ok(new { success = true, message = $"Label Added Successful" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteLabel/{NoteId}")]
        public async Task<ActionResult> RemoveLabel(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserID = Int32.Parse(userid.Value);
                var level = fundooContext.Label.FirstOrDefault(x => x.UserId == UserID && x.NoteId == NoteId);
                if (level == null)
                    return this.BadRequest(new { success = false, message = "Sorry! This lavbel does not exist." });
                await this.labelBL.Removelabel(UserID, NoteId);
                return this.Ok(new { success = true, message = "Label Removed Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet("GetParticularLabel/{NoteId}")]

        public async Task<ActionResult> GetLabel(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                Label label = await this.labelBL.GetLabel(userId, NoteId);
                return this.Ok(new { sucess = true, message = "Required label is:", data = label });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("GetAllLabel")]

        public async Task<ActionResult> GetAllLabel()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                List<Label> level = await this.labelBL.GetAllLabel(UserId);
                return this.Ok(new { success = true, message = " List of all Label :", data = level });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateLabel/{NoteId}")]
        public async Task<ActionResult> UpdateLabel(int NoteId, string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var lebel = fundooContext.Label.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == userId);
                if (lebel == null)
                {
                    return this.BadRequest(new { success = false, message = "Note not added" });
                }
                await this.labelBL.UpdateLabel(userId, NoteId, LabelName);
                return this.Ok(new { success = true, message = $"Label updated Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
