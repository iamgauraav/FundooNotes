using BussinessLayer.Interface;
using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;

        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }

        public async Task CreateLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                await labelRL.CreateLabel(UserId, NoteId, LabelName);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException.Message);
            }
        }
        public async Task Removelabel(int UserId, int NoteId)
        {
            try
            {
                await this.labelRL.Removelabel(UserId, NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Label> GetLabel(int UserId, int NoteId)
        {
            try
            {
                return await this.labelRL.GetLabel(UserId, NoteId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
