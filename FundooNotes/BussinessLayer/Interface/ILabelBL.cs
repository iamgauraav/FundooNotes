using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface ILabelBL
    {
        Task CreateLabel(int UserId, int NoteId, string LabelName);
    }
}
