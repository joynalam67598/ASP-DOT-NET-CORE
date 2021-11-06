﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Model
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name ="Regitered Email Address")]
        public string Email { get; set; }

        public bool EmailSent { get; set; }

    }
}
