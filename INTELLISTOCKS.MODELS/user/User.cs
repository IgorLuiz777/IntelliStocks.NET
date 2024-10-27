using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace INTELLISTOCKS.MODELS.user
{
    public class User
    {
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Name {  get; set; }

        public string Password { get; set; }

        public User(string password)
        {
            var hashedPass =  HashPassword(password);
            Password = hashedPass;
        }
        
    }
}
