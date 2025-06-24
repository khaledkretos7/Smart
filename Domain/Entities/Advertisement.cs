using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Author")]
        public int UserId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public float? Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Images { get; set; }
    }
}