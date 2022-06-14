using DataBaseLayer.Collaborator;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface ICollabBL
    {
        Task AddCollab(int UserId, int NoteId, CollabModel collabModel);

        Task RemoveCollab(int UserId, int NoteId);

        Task<List<Collaborator>> GetallCollab(int UserId);
    }
}
