using DataBaseLayer.Collaborator;
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

    public class CollabRL : ICollabRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;
        public CollabRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundoocontext = fundooContext;
            this.configuration = configuration;
        }
        public async Task AddCollab(int UserId, int NoteId, CollabModel collabModel)
        {
            try
            {
                Collaborator collabrator = new Collaborator
                {
                    UserId = UserId,
                    NoteId = NoteId
                };
                collabrator.CollabEmail = collabModel.CollabEmail;
                fundoocontext.Add(collabrator);
                await fundoocontext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task RemoveCollab(int UserId, int NoteId)
        {
            try
            {
                var collab = fundoocontext.Collaborator.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == UserId);
                if (collab != null)
                {
                    fundoocontext.Collaborator.Remove(collab);
                    await fundoocontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<Collaborator>> GetallCollab(int UserId)
        {
            try
            {
                List<Collaborator> collab = new List<Collaborator>();

                collab = await fundoocontext.Collaborator.Where(x => x.UserId == UserId).ToListAsync();
                return collab;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
