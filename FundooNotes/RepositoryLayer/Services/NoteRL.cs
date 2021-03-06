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
        public async Task ChangeColor(int UserId, int NoteId, string Color)
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
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

        public async Task PinNote(int UserId, int NoteId)
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
                if (note != null)
                {
                    if (note.IsTrash == false)
                    {
                        if (note.IsArchieve == true)
                        {
                            note.IsArchieve = false;

                        }
                        if (note.IsArchieve == false)
                        {
                            note.IsArchieve = true;
                        }
                    }
                    await fundoocontext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ArchiveNote(int UserId, int NoteId)
        {
            try
            {
                try
                {
                    var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
                    if (note != null)
                    {
                        if (note.IsTrash == false)
                        {
                            if (note.IsArchieve == true)
                            {
                                note.IsArchieve = false;

                            }
                            if (note.IsArchieve == false)
                            {
                                note.IsArchieve = true;
                            }
                        }
                        await fundoocontext.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task TrashNote(int UserId, int NoteId)
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
                if (note != null)
                {
                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;

                    }
                    else
                    {
                        note.IsTrash = false;
                    }
                    await fundoocontext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task RemoveNote(int NoteId, int UserId)
        {
            try
            {
                var note = fundoocontext.Note.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == UserId);
                if (note != null)
                {
                    fundoocontext.Note.Remove(note);
                    await fundoocontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<List<Note>> GetallNotes(int UserId)
        {
            try
            {
                List<Note> result = new List<Note>();

                result = await fundoocontext.Note.Where(x => x.UserId == UserId).ToListAsync();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
