using BussinessLayer.Interface;
using DataBaseLayer.Notes;
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
    public class NoteController : ControllerBase
    {
        FundooContext fundooContext;
        INoteBL noteBL;
        public NoteController(FundooContext fundooContext, INoteBL noteBL)
        {
            this.fundooContext = fundooContext;
            this.noteBL = noteBL;
        }
        [Authorize]
        [HttpPost("AddNote")]
        public async Task<ActionResult> AddNote(NotePostModel notePostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.noteBL.AddNote(userId, notePostModel);
                return this.Ok(new { success = true, message = $"Note Added Successfully" });

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("ChangeColor/{NoteId}/{Color}")]

        public async Task<ActionResult> ChangeColor(int NoteId, string Color)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, messagge = "Note Does Not Exists" });
                }
                await this.noteBL.ChangeColor(userId, NoteId, Color);
                return this.Ok(new { sucess = true, message = "Changed Color Successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("UpdateNote/{NoteId}")]

        public async Task<ActionResult> UpdateNote(int NoteId, UpdateModel updateModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, messagge = "Note Does Not Exists" });
                }
                await this.noteBL.UpdateNote(userId, NoteId, updateModel);
                return this.Ok(new { sucess = true, message = "Update Successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("GetParticularNote/{NoteId}")]

        public async Task<ActionResult> GetNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                Note note = await this.noteBL.GetNote(userId, NoteId);
                return this.Ok(new { sucess = true, message = "Required note is:", data = note });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("PinNote/{NoteId}")]
        public async Task<ActionResult> PinNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.PinNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Pinned Successfully" });
            }


            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("ArchiveNote/{NoteId}")]
        public async Task<ActionResult> ArchiveNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.ArchiveNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Archived Successfully" });
            }


            catch (Exception)
            {

                throw;
            }
        }
    }
}
