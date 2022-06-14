using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Collaborator
{
    public class CollabModel
    {
        [Required]
        [RegularExpression("^[a-z 0-9]{3,}[@][a-z]{4,}[.][a-z]{3,}$", ErrorMessage = "Please Enter a Valid Email")]
        public string CollabEmail { get; set; }
    }
}
