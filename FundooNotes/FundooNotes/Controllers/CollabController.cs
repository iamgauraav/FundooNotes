using BussinessLayer.Interface;
using DataBaseLayer.Collaborator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        FundooContext fundooContext;
        ICollabBL collabBL;

        public CollabController(FundooContext fundooContext, ICollabBL collabBL)
        {
            this.fundooContext = fundooContext;
            this.collabBL = collabBL;

        }
        [Authorize]
        [HttpPost("AddCollaborator/{NoteId}")]
        public async Task<ActionResult> AddNote(int NoteId, CollabModel  collabModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.collabBL.AddCollab(userId, NoteId, collabModel);
                return this.Ok(new { success = true, message = $"Collaborator Added Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteCollaborator/{NoteId}")]
        public async Task<ActionResult> RemoveCollab(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserID = Int32.Parse(userid.Value);
                var note = fundooContext.Collaborator.FirstOrDefault(x => x.UserId == UserID && x.NoteId == NoteId);
                if (note == null)
                    return this.BadRequest(new { success = false, message = "Sorry! This note does not exist." });
                await this.collabBL.RemoveCollab(UserID, NoteId);
                return this.Ok(new { success = true, message = "Collababorators Removed Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet("GetallCollab")]
        public async Task<ActionResult> GetallCollab()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                List<Collaborator> collab = await this.collabBL.GetallCollab(UserId);
                return this.Ok(new { success = true, message = " List of all Collaborators :", data = collab });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}