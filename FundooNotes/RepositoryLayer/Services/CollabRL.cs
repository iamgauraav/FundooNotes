using DataBaseLayer.Collaborator;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
