using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Models
{
    public class AuthResponse
    {
        public string jwt { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}
