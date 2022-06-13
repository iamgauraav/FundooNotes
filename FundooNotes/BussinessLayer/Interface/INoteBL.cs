﻿using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(int UserId, NotePostModel notePostModel);

        Task ChangeColor(int UserId, int NoteId, string Color);
    }
}
