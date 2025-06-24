using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PublicService
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("CategoryNavigation")]
        public int Category { get; set; }
        public PublicServiceCategory CategoryNavigation { get; set; }
        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}