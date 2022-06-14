using DataBaseLayer.Collaborator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICollabRL
    {
        Task AddCollab(int UserId, int NoteId, CollabModel collabModel);
    }
}
