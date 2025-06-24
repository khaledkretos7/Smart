using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Author")]
        public int UserId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public string DeletionType { get; set; }
    }
}