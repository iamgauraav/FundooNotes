﻿using DataBaseLayer.Collaborator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface ICollabBL
    {
        Task AddCollab(int UserId, int NoteId, CollabModel collabModel);
    }
}
