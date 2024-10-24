﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTELLISTOCKS.MODELS.user
{
    public class User
    {
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Name {  get; set; }

        public string Password { get; set; }
    }
}
