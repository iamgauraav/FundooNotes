using BussinessLayer.Interface;
using DataBaseLayer.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
    public class NoteController : ControllerBase
    {
        FundooContext fundooContext;
        INoteBL noteBL;

        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public NoteController(FundooContext fundooContext, INoteBL noteBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
           
            this.fundooContext = fundooContext;
            this.noteBL = noteBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
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
        [Authorize]
        [HttpPut("TrashNote/{NoteId}")]
        public async Task<ActionResult> TrashNote(int NoteId)
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
                await this.noteBL.TrashNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note trashed Successfully" });
            }


            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("Delete/{NoteId}")]
        public async Task<ActionResult> RemoveNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Deletion Failed" });
                }
                await this.noteBL.RemoveNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Deleted Successfully" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetallNote")]
        public async Task<ActionResult> GetAllNotes()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                List<Note> note = await this.noteBL.GetallNotes(UserId);
                return this.Ok(new { success = true, message = "Required note is:", data = note });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet("GetAllNotesRedisCache")]
        public async Task<ActionResult> GetAllNoteByRedisCache()
        {
            try
            {
                var CacheKey = "NoteList";
                string serializeNoteList;
                var noteList = new List<Note>();
                var redisNoteList = await distributedCache.GetAsync(CacheKey);
                if (redisNoteList != null)
                {
                    serializeNoteList = Encoding.UTF8.GetString(redisNoteList);
                    noteList = JsonConvert.DeserializeObject<List<Note>>(serializeNoteList);
                }
                else
                {
                    var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                    int UserID = Int32.Parse(userid.Value);
                    noteList = await this.noteBL.GetallNotes(UserID);
                    serializeNoteList = JsonConvert.SerializeObject(noteList);
                    redisNoteList = Encoding.UTF8.GetBytes(serializeNoteList);
                    var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(20)).SetAbsoluteExpiration(TimeSpan.FromHours(6));
                    await distributedCache.SetAsync(CacheKey, redisNoteList, option);
                }
                return this.Ok(new { success = true, message = "Get note successful", data = noteList });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
