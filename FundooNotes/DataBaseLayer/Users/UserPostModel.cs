﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Users
{
    public class UserPostModel
    {
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{8,}$", ErrorMessage = "name starts with Cap and has minimum 8 characters")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{8,}$", ErrorMessage = "name starts with Cap and has minimum 8 characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-z 0-9]{3,}[@][a-z]{4,}[.][a-z]{3,}$", ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[a-z]{3,}[0-9]{1,}[$]$", ErrorMessage = "Please Enter a Valid Password")]
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
