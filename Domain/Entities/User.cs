using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(100)]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        [Required]
        public string ApartmentNumber { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public bool IsBanned { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Post> Posts { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}