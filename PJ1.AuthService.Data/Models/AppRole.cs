using System;
using Microsoft.AspNetCore.Identity;

namespace PJ1.AuthService.Data.Models
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}