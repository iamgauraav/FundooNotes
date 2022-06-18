using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Label
{
    public class LabelPostModel
    {
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{3,}$", ErrorMessage = "name starts with Cap and has minimum 3 characters")]

        public string LabelName { get; set; }
    }
}
