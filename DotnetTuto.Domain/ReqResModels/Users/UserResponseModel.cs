using DotnetTuto.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetTuto.Domain.ReqResModels.Users
{
    public class UserResponseModel :BaseResponseModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Range(18, 69)]
        public int Age { get; set; }

        public bool IsSingle { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
