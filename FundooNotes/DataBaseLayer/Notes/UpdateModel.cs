﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class UpdateModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; } 

        public string Color { get; set; }

        public bool IsPin { get; set; }

        public bool IsArchieve { get; set; }
                 
        public bool IsTrash { get; set; }

    }
}
