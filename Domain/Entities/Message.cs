using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public User Sender { get; set; }
        [ForeignKey("Recipient")]
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public string DeletionType { get; set; }
    }
}