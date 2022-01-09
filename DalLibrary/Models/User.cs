using System;
using System.Collections.Generic;

#nullable disable

namespace DalLibrary.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string Username { get; set; }
    }
}
