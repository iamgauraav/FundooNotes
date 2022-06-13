﻿using BussinessLayer.Interface;
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

       
    }
}
