﻿using System.ComponentModel.DataAnnotations;

namespace ScratchCardManagement.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
