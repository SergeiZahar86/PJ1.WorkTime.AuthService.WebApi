using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WorkTime.AuthSerice.Data.Models
{
    /// <summary>
    /// Отработанное время
    /// </summary>
    public class WorkedTimes
    {
        /// <summary>
        /// Id модели
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Время начала
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// Время окончания
        /// </summary>
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        [Required]
        public AppUser User { get; set; }
    }
}
