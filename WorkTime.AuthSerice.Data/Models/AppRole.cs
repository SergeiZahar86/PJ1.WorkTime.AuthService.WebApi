using System;
using Microsoft.AspNetCore.Identity;

namespace WorkTime.AuthSerice.Data.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}