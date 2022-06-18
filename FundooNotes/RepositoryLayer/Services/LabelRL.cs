﻿using DataBaseLayer.Label;
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
    public class LabelRL :  ILabelRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;

        public LabelRL(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.fundoocontext = fundoocontext;
            this.configuration = configuration;
        }

        public async Task CreateLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                Label label = new Label
                {
                    UserId = UserId,
                    NoteId = NoteId

                };
                label.LabelName = LabelName;
                fundoocontext.Add(label);
                await fundoocontext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException.Message);
            }
        }
        public async Task Removelabel(int UserId, int NoteId)
        {
            try
            {
                var level = fundoocontext.Label.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == UserId);
                if (level != null)
                {
                    fundoocontext.Label.Remove(level);
                    await fundoocontext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}