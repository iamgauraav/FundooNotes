﻿using BussinessLayer.Interface;
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
    }
}