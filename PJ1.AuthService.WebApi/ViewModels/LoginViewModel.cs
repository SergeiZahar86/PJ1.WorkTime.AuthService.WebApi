﻿using System.ComponentModel.DataAnnotations;

namespace PJ1.AuthService.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required] public string UserName { get; set; } = "admin";

        [Required] public string Password { get; set; } = "123qwe";

        [Required] public string ReturnUrl { get; set; }
    }
}