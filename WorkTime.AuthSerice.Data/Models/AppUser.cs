using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTime.AuthSerice.Data.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Список отработанного времени
        /// </summary>
        public List<WorkedTimes> WorkTimeList { get; set; }
    }
}
