using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FundooContext : DbContext
    {  
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Label> Label { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Collaborator>()
                .HasKey(t => new { t.UserId, t.NoteId });

            modelBuilder.Entity<Label>()
                .HasKey(t => new { t.UserId, t.NoteId });

        }
    }
}
