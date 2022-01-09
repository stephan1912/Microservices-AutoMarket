using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;



namespace DalLibrary.Models
{
    public partial class User: IdentityUser
    {
        public bool Active { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
