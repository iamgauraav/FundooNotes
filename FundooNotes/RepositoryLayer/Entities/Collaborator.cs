using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    [Keyless]
    public class Collaborator
    {
        [Required]
        [ForeignKey("Note")]
        public int NoteId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string CollabEmail { get; set; }
    }
}
