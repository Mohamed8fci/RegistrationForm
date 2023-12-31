﻿using System.ComponentModel.DataAnnotations;

namespace registrationTask.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }
    }
}
