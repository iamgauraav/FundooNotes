using BussinessLayer.Interface;
using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        { 
            this.noteRL = noteRL;
        }

        public async Task AddNote(int UserId, NotePostModel notePostModel)
        {
            try
            {
                await noteRL.AddNote(UserId, notePostModel);
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
                await noteRL.ChangeColor(UserId, NoteId, Color);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel )
        {
            try
            {
                await noteRL?.UpdateNote(UserId, NoteId, updateModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  Task<Note> GetNote(int UserId, int NoteId)
        {
            try
            {
                return  this.noteRL.GetNote(UserId, NoteId);
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
                await noteRL.PinNote(UserId, NoteId);
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
                await noteRL.ArchiveNote(UserId, NoteId);
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
                await noteRL.TrashNote(UserId, NoteId);
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
                await this.noteRL.RemoveNote(NoteId, UserId);
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
                return await this.noteRL.GetallNotes(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
