using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRL
    {
        Task CreateLabel(int UserId, int NoteId, string LabelName);

        Task Removelabel(int UserId, int NoteId);

        Task<Label> GetLabel(int UserId, int NoteId);

        Task<List<Label>> GetAllLabel(int UserId);

        Task UpdateLabel(int UserId, int NoteId, string LabelName);

    }
}
