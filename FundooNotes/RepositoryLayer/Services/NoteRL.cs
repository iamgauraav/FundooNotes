using DataBaseLayer.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;

        public NoteRL(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.fundoocontext = fundoocontext;
            this.configuration = configuration;
        }
        public async Task AddNote(int UserID, NotePostModel notePostModel)
        {
            try
            {
                Note note = new Note();
                note.UserId = UserID;
                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.Color = notePostModel.Color;
                note.IsPin = false;
                note.IsArchieve = false;
                note.IsRemainder = false;
                note.CreateDate = DateTime.Now;
                note.ModifiedDate = DateTime.Now;  
                fundoocontext.Add(note);
                await fundoocontext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task ChangeColor(int UserId, int NoteId,string Color )
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId &&  u.NoteId == NoteId);
                if (note != null)
                {
                    note.Color = Color;
                    await fundoocontext.SaveChangesAsync();
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel)
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
                if (note != null)
                {
                    note.Title = updateModel.Title;
                    note.Description = updateModel.Description;
                    note.Color = updateModel.Color;
                    note.IsArchieve = updateModel.IsArchieve;
                    note.IsPin = updateModel.IsPin;
                    note.IsTrash = updateModel.IsTrash;
                    await fundoocontext.SaveChangesAsync();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Note> GetNote(int UserId, int NoteId)
        {
            try
            {
                return await fundoocontext.Note.FirstOrDefaultAsync(u => u.UserId == UserId && u.NoteId == NoteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
